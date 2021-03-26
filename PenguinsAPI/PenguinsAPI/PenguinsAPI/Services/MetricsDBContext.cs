/****************************************************************************************************
 * Name:    MetricsDBcontext.cs                                                                     *
 * By:      TeamPenguins                                                                            *
 * Purpose: Serves as the Data Accessability                                                        *
 ****************************************************************************************************/
using Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class MetricsDBContext : DbContext
    {
        /// Name:       Constructor
        /// Params:     options, passes database to controller
        /// Purpose:    Instantiates a data layer for MVC
        public MetricsDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Metrics> Metrics { get; set; }     // I honestly don't have the slightest clue why this is here when the constructor doesn't set it.
    }


}
