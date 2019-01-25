using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace BankLoan
{
    internal class Program
    {
        public class ReceivedLoan
        {
            public DateTime DateOfReceiving { get; set; }
            public decimal TotalLoan { get; set; }
        }

        public class PaymentLoan
        {
            internal struct SeparatePayment
            {
                public DateTime DateOfPayment { get; internal set; }
                public decimal SumPayment { get; internal set; }
            }

            private List<SeparatePayment> PaymentList { get; }

            public PaymentLoan()
            {
                var pmtList = new List<SeparatePayment>();
                PaymentList = pmtList;
            }

            public void AddPayment(string strDate, decimal sumPayment)
            {
                AddPayment(strDate, sumPayment, false);
            }

            public void AddPayment(string strDate, decimal sumPayment,
                                   bool ifMessage = true)
            {
                var dateOfPayment = Convert.ToDateTime(strDate);
                var separatePayment = new SeparatePayment
                    {DateOfPayment = dateOfPayment, SumPayment = sumPayment};
                PaymentList.Add(separatePayment);
                if (ifMessage)
                    Console.WriteLine(MessageOfPayment(strDate, sumPayment));
            }

            public void PrintListOfPayment()
            {
                var len = 0;
                foreach (var pmt in PaymentList)
                {
                    var s =
                        MessageOfPayment(pmt.DateOfPayment.ToShortDateString(),
                                         pmt.SumPayment);
                    if (s.Length > len) len = s.Length;
                    Console.WriteLine(s);
                }

                Console.WriteLine(string.Concat(Enumerable.Repeat("-", len)));
                Console
                    .WriteLine("Total payments received in the amount of: {0}=",
                               TotalPayment);
            }

            public decimal TotalPayment
            {
                get
                {
                    if (PaymentList.Count == 0) return 0;
                    var total = PaymentList.Sum(x => x.SumPayment);
                    return total;
                }
            }

            private static string MessageOfPayment(
                string strDate, decimal sumPayment) =>
                strDate + " you payment in the amount of " + sumPayment +
                " was made.";
        }

        internal class Customer
        {
            public string Name { get; set; }

            public decimal
                GetBalance(ReceivedLoan amount, PaymentLoan pmtLoan) =>
                amount.TotalLoan - pmtLoan.TotalPayment;

            public void MessageStatement(ReceivedLoan amount,
                                         PaymentLoan pmtLoan)
            {
                Console.WriteLine("The amount of your loan {0}, received {1}",
                                  amount.TotalLoan, amount.DateOfReceiving);
                Console.WriteLine(string.Concat(Enumerable.Repeat("*", 15)));
                pmtLoan.PrintListOfPayment();
                var balance = amount.TotalLoan - pmtLoan.TotalPayment;
                var output = "The balance of your account as of " +
                             DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss") +
                             " is: " +
                             balance.ToString(CultureInfo.InvariantCulture) +
                             "=";
                Console.WriteLine(string.Concat(Enumerable.Repeat("-",
                                                                  output
                                                                      .Length)));
                Console.WriteLine(output);
                if (balance > 0)
                {
                    Console.WriteLine("You must bank {0} =", balance);
                }
                else if (balance < 0)
                {
                    Console.WriteLine("The bank has a debt of {0} to you =",
                                      -balance);
                }
                else if (balance == 0)
                {
                    Console.WriteLine("Your account balance is 0 =. " +
                                      "There are no mutual obligations between " +
                                      "you and the bank.");
                }
            }
        }

        private static void Main()
        {
            var customer = new Customer();
            customer.Name = "John Doe";

            var receivedLoan = new ReceivedLoan
            {
                DateOfReceiving = Convert.ToDateTime("01.01.2020"),
                TotalLoan = 1000
            };

            var payment = new PaymentLoan();

            payment.AddPayment("17.01.2020", 100);
            payment.AddPayment("17.01.2020", 200);
            payment.AddPayment("18.01.2020", 300);
            payment.AddPayment("19.01.2020", 400);
            payment.AddPayment("18.01.2020", 50);

            customer.MessageStatement(receivedLoan, payment);
            Console.WriteLine();
        }
    }
}