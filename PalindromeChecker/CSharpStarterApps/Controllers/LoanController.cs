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
using CSharpStarterApps.Helpers;


//to link to folders each time the first public class should be named after the folder of the view. When being stated again for the ILogger it should be referred to the same way. You do not need a model and HttpGet in order to have the View displayed.
namespace CSharpStarterApps.Controllers
{
    public class Loancalculator : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public Loancalculator(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Calculator()
        {
            Loan loan = new();

            loan.Payment = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.TotalCost = 0.0m;
            loan.Rate = 3.5m;
            loan.LoanAmount = 150000m;
            loan.Term = 60;

            return View(loan);
 
        }
        //Indicating what the action is doing will allow the two Action to share the same name.
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Calculator(Loan loan)
        {
            //Calculate the loan.... and get the payments.

            var loanHelper = new LoanHelper();

            Loan newLoan = loanHelper.GetPayments(loan);
            //private classes are not visible to the caller... only public.
             


            return View(newLoan);
        }
     }

}