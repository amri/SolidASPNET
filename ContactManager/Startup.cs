﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace ContactManager
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment app)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(app.ApplicationBasePath);
            builder.AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            AppSettings.Title =  configuration.Get<string>("AppSettings:Title");
            AppSettings.ConnectionString = configuration.Get<string>("Data:DefaultConnection:ConnectionString");

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework().AddSqlServer();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });

            
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
