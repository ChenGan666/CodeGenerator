using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _company_._project_.Service.Filters;
using FJData.Utils.Core.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _company_._project_.CMSWeb
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc().AddNewtonsoftJson();

            // cors
            //services.AddCors(o => o.AddPolicy("FilePolicy", builder =>
            //{
            //    builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader();
            //}));

            services.AddMvc(option => { option.Filters.Add(new GlobalExceptionFilter()); });
            // session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                //options.Cookie.IsEssential = true;
            });

            services.AddHttpContextAccessor();

            ServiceLocator.SetService(services);
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // done
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "sitemap",
                    pattern: "sitemap.xml",
                    defaults: new { controller = "Sitemap", action = "Index" });
                
                endpoints.MapControllerRoute(
                    name: "sitemap",
                    pattern: "sitemap",
                    defaults: new { controller = "Sitemap", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "subjectDetail",
                    pattern: "subject/{subject}/{id}",
                    defaults: new { controller = "Subject", action = "Detail" });

                endpoints.MapControllerRoute(
                    name: "subject",
                    pattern: "subject/{subject}",
                    defaults: new { controller = "Subject", action = "Index" });
               
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
