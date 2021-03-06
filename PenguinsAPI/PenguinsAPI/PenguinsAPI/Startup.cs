/*****************************************************************
 * Name:    Startup.cs                                           *
 * By:      TeamPenguins                                         *
 * Purpose: Startups the website                                 *
 ****************************************************************/
using Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenguinsAPI
{
    public class Startup
    {
        /// Name:       Constructor
        /// Params:     configuration:IConfiguration
        /// Purpose:    Sets the configuration for initiliazation
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// Name:       ConfigureServices
        /// Params:     services:IServiceCollection, the set of services to be used by the web server.
        /// Purpose:    This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //Allows SQL connections
            services.AddDbContext<MetricsDBContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            //Enables use of repo
            services.AddScoped<IMetricsRepository, DBMetricsRepository>();
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod().AllowAnyHeader());
            });
        }

        /// Name:       Configure
        /// Params:     app:IApplicationBuilder, builds the application; env:IWebHostEnviornment, the web enviornment.
        /// Purpose:    This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
