using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Penguins_Front_End.Services;

namespace Penguins_Front_End
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            SeedData(host); //Seed data on startup
            host.Run();
        }

        /// <summary>
        /// Seeds the data.
        /// </summary>
        /// <param name="host">The host.</param>
        private static void SeedData(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var initializer = services.GetRequiredService<Initializer>();
                initializer.SeedUsersAsync().Wait();
            }
            catch (Exception)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError("An error occured while seeding the database.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
