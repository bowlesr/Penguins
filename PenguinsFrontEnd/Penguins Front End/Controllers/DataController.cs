using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Penguins_Front_End.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Penguins_Front_End.Controllers
{
    /// The Data Controller
    /// This Controller holds the methods to manipulate data
    /// Admin priveleges
    [Authorize(Roles = "Admin")]
    public class DataController : Controller
    {
        //API Path
        private string url = "http://penguinsapi.us-east-1.elasticbeanstalk.com/api/Metrics";
        //List of metrics
        private List<MetricsVM> data = new List<MetricsVM>();

        //Empty Constructor to be able to create an object for testing
        public DataController() { }

        /// <summary>
        /// 
        /// Index method to create the view
        /// 
        /// </summary>
        /// <returns>View of Data</returns>
        public async Task<ActionResult> Index()
        {
            //Using HTTPClient to access data from the api and converts the data to JSON
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

        /// <summary>
        /// 
        /// Get create method
        /// 
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 
        /// Post create method
        /// 
        /// </summary>
        /// <param name="metricsVM"></param>
        /// <returns>redirected to index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MetricsVM metricsVM)
        {
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

        /// <summary>
        /// Get method of delete 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Redirected to index view</returns>
        public ActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var deleteTask = client.DeleteAsync(url + "/" + id.ToString());
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
    }
}
