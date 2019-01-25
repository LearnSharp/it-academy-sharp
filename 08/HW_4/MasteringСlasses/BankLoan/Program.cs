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
            public PaymentLoan(DateTime dateOfPayment, decimal sumPayment)
            {
                DateOfPayment = dateOfPayment;
                SumPayment = sumPayment;
            }

            public DateTime DateOfPayment { get; set; }
            public decimal SumPayment { get; set; }
        }

        internal class Customer
        {
            public string Name { get; set; }

            public List<PaymentLoan> PaymentList { get; set; }

            public string RepaymentService(decimal amount, decimal payment)
            {
                var total = PaymentList.Sum(x => x.SumPayment);
                total += payment;
                var balance = amount - total;
                var str = balance.ToString(CultureInfo.InvariantCulture);

                return str;
            }
        }

        private static void Main()
        {
            var customer = new Customer
            {
                Name = "John Doe",
                PaymentList = new List<PaymentLoan>(),
            };

            var receivedLoan = new ReceivedLoan
            {
                DateOfReceiving = Convert.ToDateTime("01.01.2020"),
                TotalLoan = 1000,
            };

            var paymentLoan =
                new PaymentLoan(Convert.ToDateTime("17.01.2020"), 100);
            customer.PaymentList.Add(paymentLoan);

            var paymentLoan1 =
                new PaymentLoan(Convert.ToDateTime("19.01.2020"), 200);
            customer.PaymentList.Add(paymentLoan1);

            var str = customer.RepaymentService(receivedLoan.TotalLoan, 50);

            Console.WriteLine("result = " + str);
        }
    }
}