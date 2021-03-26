/*****************************************************************
 * Name:    Program.cs                                           *
 * By:      TeamPenguins                                         *
 * Purpose: Website Launch Point                                 *
 ****************************************************************/
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenguinsAPI
{
    public class Program
    {
        /// Name:       Main
        /// Params:     args:String[]
        /// Purpose:    Creates the host, builds it, and runs it
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// Name:       CreateHostBuilder
        /// Params:     args:String[]
        /// Purpose:    Makes the host using webBuilder's startup functionality
        /// Returns:    x:IHostBuilder, returns the hostbuilder used to make the website
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
