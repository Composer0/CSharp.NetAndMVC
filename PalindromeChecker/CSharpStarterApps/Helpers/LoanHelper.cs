using CSharpStarterApps.Models;
using System;

namespace CSharpStarterApps.Helpers
{
    public class LoanHelper
    {
        //Need to calculate a payment first.
        public Loan GetPayments(Loan loan)
        {
            //Calculate Monthly Payment
            loan.Payment = CalcPayment(loan.LoanAmount, loan.Rate,loan.Term);
            //corrected Term to be an int in the Model.

            //Create a loop from 1 to the term.
            var balance = loan.LoanAmount;
            var totalInterest = 0.0m;
            var monthlyInterest = 0.0m;
            var monthlyPrincipal = 0.0m;
            var monthlyRate = CalcMonthlyRate(loan.Rate);

            //loop over each month until we reach the term of the loan.
            for (int month = 1; month < loan.Term; month++)
            {
                monthlyInterest = CalcMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterest;
                monthlyPrincipal = loan.Payment - monthlyInterest;
                balance -= monthlyPrincipal;

                LoanPayment loanPayment = new();
                //Type Variable
                loanPayment.Month = month;
                loanPayment.Payment = loan.Payment;
                loanPayment.MonthlyPrincipal = monthlyPrincipal;
                loanPayment.MonthlyInterest = monthlyInterest;
                loanPayment.TotalInterest = totalInterest;
                loanPayment.Balance = balance;
                //Property of the object is capital. Value lowercase

                //Push the object into the Loan Model.
                loan.Payments.Add(loanPayment);
            }

            loan.TotalInterest = totalInterest;
            loan.TotalCost = loan.LoanAmount + totalInterest;

            return loan;

            //Calculate a payment schedule.


            //Push payments into the loan


            //Return the loan to the view.

        }

        private decimal CalcPayment(decimal amount, decimal rate, int term)
        {
            
            var monthlyRate = CalcMonthlyRate(rate);
            //var allows us to pull the type from the model so that we don't have to restate it. It is not the same as JavaScript.
            var rateD = Convert.ToDouble(monthlyRate);
            var amountD = Convert.ToDouble(amount);

            var paymentD = (amountD * rateD) / (1 - Math.Pow(1 + rateD, -term));



            return Convert.ToDecimal(paymentD);
        }

        private decimal CalcMonthlyRate(decimal rate)
        {
            return rate / 1200;
        }

        private decimal CalcMonthlyInterest(decimal balance, decimal monthlyRate)
        {
            return balance * monthlyRate;
        }
    }
}
