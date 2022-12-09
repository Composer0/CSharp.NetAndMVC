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
            // model = new();
            //above is how to create a new instance
            return View();
            //model is able to be inserted into the view now.
        }

    }
}
