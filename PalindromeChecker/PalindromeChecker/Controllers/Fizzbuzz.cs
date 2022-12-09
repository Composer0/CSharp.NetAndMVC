using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PalindromeChecker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PalindromeChecker.Controllers
{
    public class Fizzbuzz : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public Fizzbuzz(ILogger<HomeController> logger)
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

        [HttpGet]
        public IActionResult FizzBuzz()
        {
            FizzBuzz model = new();
            // model = new();
            //above is how to create a new instance
            model.FizzValue = 3;
            model.BuzzValue = 5;
            //The above allows these pieces of data to be shown on the View()... display page. These are the default values rather than 0.

            return View(model);
            //model is able to be inserted into the view now.
        }

    }
}
