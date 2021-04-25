using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Penguins_Front_End.Models.ViewModels;
using Penguins_Front_End.Services;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Threading;

namespace Penguins_Front_End.Controllers
{
    /// The User Controller
    /// This Controller holds the methods to create the graph
    /// Admin priveleges
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        //Variables
        private readonly IUserRepository _userRepo; //Injected the UserRepository
        private readonly IRoleRepository _roleRepo; //Injected the RoleRepository
        private string url = "http://penguinsapi.us-east-1.elasticbeanstalk.com/api/Metrics";
        private List<MetricsVM> data = new List<MetricsVM>();        

        /// <summary>
        /// 
        /// UserController Constructor
        /// 
        /// </summary>
        /// <param name="userRepo"></param>
        /// <param name="roleRepo"></param>
        public UserController(IUserRepository userRepo, IRoleRepository roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;            
        }

        /// <summary>
        /// 
        /// Empty Constructor to create object in testing
        /// 
        /// </summary>
        //public UserController()
        //{
        //}

        /// <summary>
        /// 
        /// ChartData that creates the chart
        /// 
        /// </summary>
        /// <returns>sjson object</returns>
        public string ChartData()
        {
            
            //       userName, howMany
            Dictionary<string, int> userCount = new Dictionary<string, int>(); //New Dictionary
            foreach (var item in data)
            {                
                if (userCount.ContainsKey(item.UserName))
                {
                    userCount[item.UserName] += 1;
                }
                else
                {
                    userCount.Add(item.UserName,1);
                }                
            }
            var sjson = JsonConvert.SerializeObject(userCount, Formatting.Indented); //Converts data
            sjson = sjson.Replace('{', '[');
            sjson = sjson.Replace('}', ']');
            sjson = sjson.Replace(':', ',');
            Console.WriteLine(sjson);
            
            //return json
            return sjson;
            
        }

        /// <summary>
        /// 
        /// Gets all the users Email, Username, Numberofroles, and the rolenames
        /// 
        /// </summary>
        /// <returns>view of userlist</returns>
        public async Task<IActionResult> UserList()
        {
            //Reads all
            var users = await _userRepo.ReadAllAsync();
            //Gets all user info
            var userList = users
                .Select(u => new UserListVM
                {
                    Email = u.Email,
                    UserName = u.UserName,
                    NumberOfRoles = u.Roles.Count,
                    RoleNames = string.Join(",", u.Roles.ToArray())
                });
            //return the view of data
            return View(userList);
        }

        /// <summary>
        /// 
        /// Assigns role action method
        /// 
        /// </summary>
        /// <returns>view of model</returns>
        public async Task<IActionResult> AssignRoles()
        {
            var users = await _userRepo.ReadAllAsync(); //Read all users into users asynchronously
            var roles = _roleRepo.ReadAll(); //Read all roles into roles
            var model = new AssignRoleVM(); //Instantiate model as an AssignRoleVM
            model.UserNames = users.Select(u => u.UserName).ToList(); //Select UserName from users converted to a list
            model.RoleNames = roles.Select(r => r.Name).ToList(); //Select Name from roles converted to a list
            return View(model); //Return the view with the model as parameter
        }

        /// <summary>
        /// 
        /// AssignRoles action Post method.
        /// 
        /// </summary>
        /// <param name="roleVM">The role vm.</param>
        /// <returns>redirected to index view</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRoles(AssignRoleVM roleVM)
        {
            await _userRepo.AssignRoleAsync(roleVM.UserName, roleVM.RoleName); //Call user repository's AssignRoleAsync
            return RedirectToAction("UserList", "User"); //Redirect to User List
        }
    }
}

