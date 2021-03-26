using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Penguins_Front_End.Models.Entities
{
    public class ApplicationUser : IdentityUser //Derives from IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public ICollection<string> Roles { get; set; } //Declare property Roles of type ICollection<string>

        public ApplicationUser()
        {
            Roles = new List<string>(); //Instantiated Roles as a List
        }

        public bool HasRole(string roleName)
        {
            return Roles.Any(r => r == roleName);
        }
    }
}