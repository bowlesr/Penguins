using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penguins_Front_End.Models.ViewModels
{
    public class MetricsVM
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
    }
}
