using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpliPromo.Entities;
using SimpliPromo.ViewModels;

namespace SimpliPromo
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Hosting.IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("simpliPromo.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"simpliPromo{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            if (env.IsDevelopment())
            {
                builder.AddApplicationInsightsSettings(developerMode: true);

            }
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        public IWebHostEnvironment Env {get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddDbContext<ProfileContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddMvc(options=>options.EnableEndpointRouting=false);
            services.AddRazorPages();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddProvider()
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

               //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("Main/Error");
            }
            //app.UseApplicationInsightsExceptionTelemetry();
            app.UseStaticFiles();
            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{

            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            app.UseMvc(routes=>routes.MapRoute("default","{controller=Main}/{action=Index}/{id?}"));
        }
    }
}
