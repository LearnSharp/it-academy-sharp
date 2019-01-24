using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework07_Calculate
{
    class Homework07_Calculate
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int c;

            Console.WriteLine("Enter first argument. value should be >= 0");
            while (!Int32.TryParse(Console.ReadLine(), out a) || (a < 0))
            {
                Console.WriteLine("Entered value is not valid. Try again.");
                Console.WriteLine("Enter first argument. value should be >= 0");
            }

            Console.WriteLine("Enter second argument. value should be >= 0");
            while (!Int32.TryParse(Console.ReadLine(), out b) || (b < 0))
            {
                Console.WriteLine("Entered value is not valid. Try again.");
                Console.WriteLine("Enter second argument. value should be >= 0");
            }

            Console.WriteLine("Enter third argument. value should be >= 0");
            while (!Int32.TryParse(Console.ReadLine(), out c) || (c < 0))
            {
                Console.WriteLine("Entered value is not valid. Try again.");
                Console.WriteLine("Enter third argument. value should be >= 0");
            }

            Calculate(a, b, c);

            Console.ReadKey();
        }

        public static void Calculate(int argument_1, int argument_2, int argument_3)
        {
            Console.WriteLine("Arithmetic mean value - {0}", Math.Round((argument_1 + argument_2 + argument_3) / 3.0, 2));
        }
    }
}
