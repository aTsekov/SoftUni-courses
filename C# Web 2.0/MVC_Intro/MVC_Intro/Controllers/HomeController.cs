﻿using Microsoft.AspNetCore.Mvc;
using MVC_Intro.Models;
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

            ViewBag.Message = "Hello Worold!";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET CORE MVC app.";
            return View();
        }

        public IActionResult Numbers()
        {
            return View();
        }
        public IActionResult NumbersToN(int count = -1)
        {
           ViewBag.Count = count;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}