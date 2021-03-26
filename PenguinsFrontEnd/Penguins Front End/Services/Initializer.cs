using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Penguins_Front_End.Models.Entities;

namespace Penguins_Front_End.Services
{
    public class Initializer
    {
        //Injected the data context, user manager, and role manager into Initializer
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Initializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Async method to seed users.
        /// </summary>
        public async Task SeedUsersAsync()
        {
            _db.Database.EnsureCreated();

            if (!_db.Roles.Any(r => r.Name == "Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole {Name = "Admin"});
            }

            if (!_db.Roles.Any(r => r.Name == "User"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }

            if (!_db.Users.Any(u => u.UserName == "admin@etsu.edu"))
            {
                var user = new ApplicationUser
                {
                    Email = "admin@etsu.edu",
                    UserName = "admin@etsu.edu",
                    FirstName = "AdminFirstName",
                    LastName = "AdminLastName"
                };
                await _userManager.CreateAsync(user, "Passw0rd!");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}