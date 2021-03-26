/*****************************************************************
 * Name:    Metrics.cs                                           *
 * By:      TeamPenguins                                         *
 * Purpose: Controller to manipulate the api using HTTP methods  *
 ****************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Entities
{
    public class Metrics
    {
        [Key]
        public int UserId { get; set; }         //UserID serves as Primary Key
        public string UserName { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
    }
}
