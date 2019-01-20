using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework03_optional
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int result;

            while(n <= 10)
            {
                result = 1;

                for(int i = 0; i < n; i++)
                {
                    result *= 2;
                }

                Console.WriteLine($"2 to the power {n} - {result}");
                n++;
            }

            Console.WriteLine("Press any key for exit.");
            Console.ReadKey();
        }
    }
}
