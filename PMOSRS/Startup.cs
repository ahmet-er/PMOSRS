using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using PMOSRS.Data.Core.Business;
using PMOSRS.Data.Core.Repository;

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

            


            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader());//ben ekledim

            app.UseAuthorization();

            app.UseRouting();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });

            

        }
    }
}
