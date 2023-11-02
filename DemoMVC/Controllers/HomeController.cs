using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Demo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string FullName, string Address)
        {
            string strOutput = "Xin Chao" + FullName + "Den Tu" + Address;
            ViewBag.Message = strOutput;
            return View ();
        }
    }
}
