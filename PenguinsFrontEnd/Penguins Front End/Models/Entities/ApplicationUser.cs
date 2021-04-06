using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Penguins_Front_End.Models.Entities
{
    /// <summary>
    /// 
    /// Entity Application User
    /// 
    /// </summary>
    public class ApplicationUser : IdentityUser //Derives from IdentityUser
    {
        //First name of user
        public string FirstName { get; set; }
        //Last Name of user
        public string LastName { get; set; }

        [NotMapped]
        public ICollection<string> Roles { get; set; } //Declare property Roles of type ICollection<string>

        public ApplicationUser()
        {
            Roles = new List<string>(); //Instantiated Roles as a List
        }

        //Returns roles
        public bool HasRole(string roleName)
        {
            return Roles.Any(r => r == roleName);
        }
    }
}