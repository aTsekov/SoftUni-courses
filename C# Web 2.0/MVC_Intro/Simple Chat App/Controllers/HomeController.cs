using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace MVC_Intro.Controllers
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
            //How to pass data from controller to the view
            //1. Using mode => large set of data such as forms
            //2. Using ViewBag => Random data using dynamic object
            //3. Using ViewData => Random data using dictionary

            ViewBag.Message = "Hello World!";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}