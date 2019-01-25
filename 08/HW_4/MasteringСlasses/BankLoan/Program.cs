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

            public void AddPayment(string strDate, decimal sumPayment, bool ifMessage)
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

            private static void MessageOfPayment(string strDate, decimal sumPayment)
            {

                Console.WriteLine("{0} you payment in the amount of $ {1} was made", strDate, sumPayment);
            }
        }

        internal class Customer
        {
            public string Name { get; set; }
            public decimal RepaymentService(decimal amount, ref PaymentLoan pmtLoan , decimal payment)
            {
                var total = pmtLoan.TotalPayment;
                pmtLoan.AddPayment(DateTime.Now.ToString("dd.MM.yyy"), payment, true);
                total += payment;

                return amount - total;
            }
        }

        private static void Main()
        {
            var customer = new Customer
            {
                Name = "John Doe"
            };

            var receivedLoan = new ReceivedLoan
            {
                DateOfReceiving = Convert.ToDateTime("01.01.2020"),
                TotalLoan = 1000,
            };


            var payment = new PaymentLoan();

            payment.AddPayment("17.01.2020",100, true);
            payment.AddPayment("17.01.2020", 200, true);

            payment.AddPayment("18.01.2020", 300, true);
            payment.AddPayment("19.01.2020", 400, true);

            var balance = customer.RepaymentService(receivedLoan.TotalLoan, ref payment, 50);

            Console.WriteLine("Your loan balance = {0}", balance);
        }
    }
}