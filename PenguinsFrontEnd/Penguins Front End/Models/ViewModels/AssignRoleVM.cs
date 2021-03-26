using System.Collections;
using System.Collections.Generic;

namespace Penguins_Front_End.Models.ViewModels
{
    /// <summary>
    /// AssignRole View Model
    /// </summary>
    public class AssignRoleVM
    {
        public ICollection<string> UserNames { get; set; }
        public ICollection<string> RoleNames { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}