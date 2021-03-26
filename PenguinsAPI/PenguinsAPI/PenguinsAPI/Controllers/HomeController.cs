/*****************************************************************
 * Name:    HomeController.cs                                    *
 * By:      TeamPenguins                                         *
 * Purpose: Controller to manipulate the api using HTTP methods  *
 ****************************************************************/

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenguinsAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PenguinsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// Name:       Constructor
        /// Params:     logger:ILogger<HomeController>, passes the logger
        /// Purpose:    Instantiates a new home and passes the log.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// Name:       Index
        /// Purpose:    Instantiates a new home and passes the log.
        /// Returns:    x:IActionResult, returns the action according to MVC standards
        public IActionResult Index()
        {
            return RedirectToAction("GetMetrics", "Metrics");
            //return View();
        }

        /// Name:       Privacy
        /// Purpose:    Returns the privacy view.
        /// Returns:    x:IActionResult, returns the action according to MVC standards
        public IActionResult Privacy()
        {
            return View();
        }

        /// Name:      Error
        /// Purpose:   Returns the Error View with some stuff I don't understand
        /// Returns:    x:IActionResult, returns the action according to MVC standards
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
