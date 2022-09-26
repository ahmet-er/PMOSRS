﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace PMOSRS
{
    public class ConfigureMyCookie : IConfigureNamedOptions<CookieAuthenticationOptions>
    {
        // You can inject services here
        public ConfigureMyCookie()
        {
        }
        public void Configure(string name, CookieAuthenticationOptions options)
        {
            // Only configure the schemes you want
            if(name == CookieAuthenticationDefaults.AuthenticationScheme)
            {
                // options.LoginPath = "/someotherpath";
            }
        }

        public void Configure(CookieAuthenticationOptions options)
            => Configure(Options.DefaultName, options);
    }
}
