using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework07_Loan
{
    class Homework07_Loan
    {
        static void Main(string[] args)
        {
            decimal amount;
            Loan loan = new Loan(700);
            bool decision = true;

            while(decision)
            {
                Console.WriteLine("Enter amount for payment:");
                while (!Decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                {
                    Console.WriteLine("Entered value is not valid. Value should be > 0. Try again.");
                    Console.WriteLine("Enter amount for payment:");
                }

                loan.SimplePayment(amount);

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Do you want to make one more payment? Yes or No");
                Console.WriteLine("-----------------------------------------------");

                if (!Convert.ToString(Console.ReadLine()).ToUpper().Equals("YES"))
                {
                    break; 
                }
            }  
        }
    }

    public class Loan
    {
        private bool _isClosedloan = false;
        private bool _isLoanHasDeposit = false;
        public decimal OutstandingAmount { set; get; }

        public Loan(decimal outstandingAmount)
        {
            OutstandingAmount = outstandingAmount;
            Console.WriteLine("Loan with amount = {0} has been created.", OutstandingAmount);
        }

        public void SimplePayment(decimal amount)
        {
            if(!_isClosedloan)
            {
                OutstandingAmount -= amount;

                _isClosedloan = OutstandingAmount <= 0 ? true : false;
                _isLoanHasDeposit = OutstandingAmount < 0 ? true : false;

                Console.WriteLine("Payment has been done successfully.");
                Console.WriteLine("--------------------------------------------");

                if (_isClosedloan)
                {
                    Console.WriteLine("Loan has been closed. Total outstanding amount 0 BYN");

                    if (_isLoanHasDeposit)
                    {
                        Console.WriteLine("Loan has overpayment {0} BYN", -OutstandingAmount);
                    }
                }
                else
                {
                    Console.WriteLine("Total outstanding amount {0} BYN", OutstandingAmount);
                }
            }
            else
            {
                Console.WriteLine("Payment is unpossible. Loan is closed.");
            }
            
        }
    }
}
