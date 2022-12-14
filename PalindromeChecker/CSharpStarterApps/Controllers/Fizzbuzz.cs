using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSharpStarterApps.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpStarterApps.Controllers
{
    public class Fizzbuzz : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public Fizzbuzz(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult FizzBuzzView()
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FizzBuzzView(FizzBuzz fizzbuzz)
            //Note to self. When using a class like FizzBuzz above. Do not get confused and write it as if the controller file name is the class itself. The class is inside the file name.  public IActionResult View(Class parameter)
        {
            List<string> fbItems = new();

            bool fizz;
            bool buzz;

            for (int i = 1; i <= 100; i++)
            {
                fizz = (i % fizzbuzz.FizzValue == 0);
                //calling the parameter which holds the model FizzValue and model Buzz Value
                buzz = (i % fizzbuzz.BuzzValue == 0);


                //semicolons note to self. In C# you do not need a semicolon at the end of the if or else line of code. Keep in mind that just because the brackets typically go under neath the parameters of the if and else statements it does not require a semicolon. Remember that in JavaScript they did not either. The difference is the bracket beginning directly after the statement and following through which decreases the lines of code need to describe the function.
                if (fizz == true && buzz == true)
                {
                    fbItems.Add("FizzBuzz");
                }
                else if (fizz == true)
                {
                    fbItems.Add("Fizz");
                } 
                else if (buzz == true)
                {
                    fbItems.Add("Buzz");
                } 
                else
                {
                    fbItems.Add(i.ToString());
                    //JavaScript will normally work on i alone. But in a strictly typed language we need to provide a method to convert the int into a string.
                }
            }

            fizzbuzz.Result = fbItems;

            return View(fizzbuzz);
        }

    }
}