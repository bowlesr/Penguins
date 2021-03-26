using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Penguins_Front_End.Models.Entities;

namespace Penguins_Front_End.Services
{
    /// <summary>
    /// IUserRepository implementation
    /// </summary>
    /// <seealso cref="Penguins_Front_End.Services.IUserRepository" />
    public class DbUserRepository : IUserRepository
    {
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager; //Injected UserManager

        public DbUserRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        /// <summary>
        /// Reads the ApplicationUser asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public async Task<ApplicationUser> ReadAsync(string userName) //Changed Read to ReadAsync and added the async keyword
        {
            //return _db.Users.FirstOrDefault(u => u.UserName == userName);
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName); //Use FirstOrDefaultAsync to read the user from _db.Users
            user.Roles = await _userManager.GetRolesAsync(user); //Use the user manager to get the user's roles
            return user;
        }

        /// <summary>
        /// Reads all ApplicationUsers asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<ApplicationUser>> ReadAllAsync()
        {
            var users = _db.Users;
            foreach (var user in users)
            {
                user.Roles = await _userManager.GetRolesAsync(user);
            }
            return users;
        }

        /// <summary>
        /// Assigns the role asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public async Task<bool> AssignRoleAsync(string userName, string roleName)
        {
            var user = await ReadAsync(userName); //Read the user using userName
            if (user != null)
            {
                if (!user.HasRole(roleName)) //Check if the user does not have role roleName
                {
                    await _userManager.AddToRoleAsync(user, roleName); //Use the user manager to add the role to the user
                    return true;
                }
            }
            return false;
        }
    }
}