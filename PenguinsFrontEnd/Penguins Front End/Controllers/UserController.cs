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
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo; //Injected the UserRepository
        private readonly IRoleRepository _roleRepo; //Injected the RoleRepository
        private string url = "http://penguinsapi.us-east-1.elasticbeanstalk.com/api/Metrics";
        private List<MetricsVM> data = new List<MetricsVM>();
        public UserController(IUserRepository userRepo, IRoleRepository roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        /// <summary>
        /// Index action method
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    var metrics = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<MetricsVM>>(metrics);
                }

                return View(data);
            }

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MetricsVM metricsVM)
        {
            //MetricsVM user = new MetricsVM { UserId = 33, UserName = "Bob", LoginTime = "11:25", LogoutTime = "6:30" };
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                var json = JsonConvert.SerializeObject(metricsVM);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        return RedirectToAction("Index");
                    }
                }
            } 
        }
        
        public ActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var deleteTask = client.DeleteAsync(url +"/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                //var response = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UserList()
        {
            var users = await _userRepo.ReadAllAsync();
            var userList = users
                .Select(u => new UserListVM
                {
                    Email = u.Email,
                    UserName = u.UserName,
                    NumberOfRoles = u.Roles.Count,
                    RoleNames = string.Join(",", u.Roles.ToArray())
                });
            return View(userList);
        }

        /// <summary>
        /// Assigns role action method
        /// </summary>
        /// <returns></returns>
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
        /// AssignRoles action Post method.
        /// </summary>
        /// <param name="roleVM">The role vm.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRoles(AssignRoleVM roleVM)
        {
            await _userRepo.AssignRoleAsync(roleVM.UserName, roleVM.RoleName); //Call user repository's AssignRoleAsync
            return RedirectToAction("Index", "User"); //Redirect to User Index
        }
    }
}

