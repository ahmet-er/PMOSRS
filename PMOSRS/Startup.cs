using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using PMOSRS.Data.Core.Business;
using PMOSRS.Data.Core.Repository;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace PMOSRS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient(new ProjectRepository().GetType());
            services.AddTransient(new UserRepository().GetType());
            services.AddTransient(new TSRepository().GetType());
            services.AddTransient(new TIDRepository().GetType());
            services.AddTransient(new SRSRepository().GetType());
            services.AddTransient(new SettingRepository().GetType());
            services.AddTransient(new RoleUserMapRepository().GetType());
            services.AddTransient(new RoleRepository().GetType());
            services.AddTransient(new ProjectUserMapRepository().GetType());
            services.AddTransient(new FileRepository().GetType());
            services.AddTransient(new AuthorityRoleMapRepository().GetType());
            services.AddTransient(new AuthorityRepository().GetType());

            services.AddCors();

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddMvc(x => x.EnableEndpointRouting = false).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null).AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true)
              .AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver()).AddRazorRuntimeCompilation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ".NET Core 5", Version = "v1", Description = "This test description" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //ben ekledim - sor
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true, // Olu�turulacak token de�erini kimlerin/ hangi originlerin / sitelerin kullan�c� belirledi�imiz de�erdir. www.bilmemne.com
                        ValidateIssuer = true, // Olu�turulacak token de�erini kimin da��tt���n� ifade edece�imiz aland�r -> www.myapi.com
                        ValidateLifetime = true, // Olu�turulan token de�erinin s�resini kontrol edecek olan do�rulamad�r
                        ValidateIssuerSigningKey = true, // �retilecek token de�erinin uygulamam�za ait bir de�er oldu�unu  ifade eden security key verisinin do�rulanmas�d�r.

                        ValidAudience = Configuration["Token:Audience"],
                        ValidIssuer = Configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]))
                    };
                });


             services.AddRazorPages();

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            //Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //specifying the Swagger JSON endpoint
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseMvc(routes =>
            {
                //routes.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                //routes.MapRoute(name: "default", template: "{controller=Login}/{action=Index}/{id?}");
                routes.MapRoute(
"default",
"{controller}/{action}/{id}",
 new { controller = "Login", action = "Index", id = "" });
            });

            app.UseRouting();

        }
    }
}
