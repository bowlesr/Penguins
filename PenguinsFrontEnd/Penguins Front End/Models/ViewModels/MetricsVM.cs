using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penguins_Front_End.Models.ViewModels
{
    /// <summary>
    /// 
    /// Metrics View Model
    /// 
    /// </summary>
    public class MetricsVM
    {
        //int ID of user
        public int UserId { get; set; }
        //string username
        public string UserName { get; set; }
        //string of login time of user
        public string LoginTime { get; set; }
        //string of logout time of user
        public string LogoutTime { get; set; }
    }
}
