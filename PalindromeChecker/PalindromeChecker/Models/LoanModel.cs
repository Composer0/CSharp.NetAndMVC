using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace must be present in order for models to be represented/instantiated in another model.
namespace PalindromeChecker.Models
{
    public class Loan
    {
        public decimal Payment { get; set; }
        public decimal Rate { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Term { get; set; }
        public string Message { get; set; }

        public List<LoanPayment> Payments { get; set; } = new List<LoanPayment>();
    }
}