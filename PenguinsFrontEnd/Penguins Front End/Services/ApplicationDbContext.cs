using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Penguins_Front_End.Models.Entities;

namespace Penguins_Front_End.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string> //Modified header to work with ApplicationUser and IdentityRole
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
