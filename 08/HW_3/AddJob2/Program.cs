using System;

namespace AddJob2
{
    internal class Program
    {
        private static void Main()
        {
            const int pow = 10;
            const int number = 2;
            var result = 0;
            for (var i = 1; i <= pow; ++i)
            {
                var old = result;
                result = number << i;
                Console.WriteLine("{0,-4} * 2 = {1}", old, result);
            }

            Console.WriteLine();
            result = 2;
            var it = 0;
            while (++it <= pow)
            {
                var old = result;
                result = number << it;
                Console.WriteLine("{0,-4} * 2 = {1}", old, result);
            }

            Console.WriteLine();
            result = 2 >> 1;
            it = 0;
            do
            {
                var old = result;
                result = number << it;
                Console.WriteLine("{0,-4} * 2 = {1}", old, result);
            } while (it++ < pow);
        }
    }
}