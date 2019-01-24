using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework07_FxConverter
{
    class Homework07_FxConverter
    {
        static void Main(string[] args)
        {
           decimal _amount;
           decimal _rate;

            Console.WriteLine("Enter amount for covert: ");
            while(!Decimal.TryParse(Console.ReadLine(), out _amount) || _amount <= 0)
            {
                Console.WriteLine("Entered amount is not valid. Try again.");
                Console.WriteLine("Enter amount for covert: ");
            }

            Console.WriteLine("Enter rate for covert: ");
            while (!Decimal.TryParse(Console.ReadLine(), out _rate) || _rate <= 0)
            {
                Console.WriteLine("Entered rate is not valid. Try again.");
                Console.WriteLine("Enter rate for covert: ");
            }

            Console.WriteLine("You can buy {0} units some curency", FxConverter(_amount, _rate));

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Press any key for exit.");
            Console.ReadKey();
        }

        public static decimal FxConverter(decimal amount, decimal rate)
        {
            return Math.Round(amount / rate, 2);
        }

    }
}
