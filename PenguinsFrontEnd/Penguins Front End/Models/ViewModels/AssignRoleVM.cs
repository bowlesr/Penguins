using System.Collections;
using System.Collections.Generic;

namespace Penguins_Front_End.Models.ViewModels
{
    /// <summary>
    /// 
    /// AssignRole View Model
    /// 
    /// </summary>
    public class AssignRoleVM
    {
        //Collection of usernames
        public ICollection<string> UserNames { get; set; }
        //collection of rolenames
        public ICollection<string> RoleNames { get; set; }
        //String username
        public string UserName { get; set; }
        //string of rolename
        public string RoleName { get; set; }
    }
}