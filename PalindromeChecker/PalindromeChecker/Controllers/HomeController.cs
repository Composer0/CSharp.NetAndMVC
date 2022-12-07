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

        [HttpGet]
        public IActionResult Reverse()
        {
            Palindrome model = new();
            //above is how to create a new instance
            return View(model);
            //model is able to be inserted into the view now.
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reverse(Palindrome palindrome)
            //Allowable because it has a different parameter to the one listed in the Httpget. Palindrome references established class in model. palindrome is the parameter.
        {
            string inputWord = palindrome.InputWord;
            string revWord = "";

            for(int i = inputWord.Length - 1; i >=0; i--)
            {
                revWord += inputWord[i];
            }

            palindrome.RevWord = revWord;
            //Recreates the word by making it go backwards.

            revWord = Regex.Replace(revWord.ToLower(), "[^a-zA-Z0-9]+","");
            inputWord = Regex.Replace(inputWord.ToLower(), "[^a-zA-Z0-9]+", "");

            if(revWord == inputWord)
            {
                palindrome.IsPalindrome = true;
                palindrome.Message = $"Success {palindrome.InputWord} is a Palindrome";
            }
            else
            {
                palindrome.IsPalindrome = false;
                palindrome.Message = $"Sorry {palindrome.InputWord} is not a Palindrome";
            }

            return View(palindrome);
            //By adding a return value we can eliminate the potential error that occurs from creating another class of the same name. It can be the same as long as the parameters are different.
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
