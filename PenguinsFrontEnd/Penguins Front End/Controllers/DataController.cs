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
    [Authorize(Roles = "Admin")]
    public class DataController : Controller
    {
        private string url = "http://penguinsapi.us-east-1.elasticbeanstalk.com/api/Metrics";
        private List<MetricsVM> data = new List<MetricsVM>();

        // GET: DataController1
        public async Task<ActionResult> Index() 
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

        // GET: DataController1/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: DataController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataController1/Create
        [HttpPost] 
        [ValidateAntiForgeryToken]
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

        // GET: DataController1/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DataController1/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: DataController1/Delete/5
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

        // POST: DataController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
