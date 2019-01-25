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

            private delegate void Message(string strDate, decimal sumPayment);


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
                Message message = MessageOfPayment;
                if (ifMessage) message(strDate, sumPayment);
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

            private static void MessageOfPayment(
                string strDate, decimal sumPayment)
            {
                Console
                    .WriteLine("{0} you payment in the amount of $ {1} was made",
                               strDate, sumPayment);
            }
        }

        internal class Customer
        {
            public string Name { get; set; }

            public decimal
                GetBalance(ReceivedLoan amount, PaymentLoan pmtLoan) =>
                amount.TotalLoan - pmtLoan.TotalPayment;
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

            payment.AddPayment("17.01.2020", 100, true);
            payment.AddPayment("17.01.2020", 200);
            payment.AddPayment("18.01.2020", 300);
            payment.AddPayment("19.01.2020", 400, true);
            payment.AddPayment("18.01.2020", 50);

            var balance =
                customer.GetBalance(receivedLoan, payment);

            Console.WriteLine("Your loan balance = {0}", balance);
        }
    }
}