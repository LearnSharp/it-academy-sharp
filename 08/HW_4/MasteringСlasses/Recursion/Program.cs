using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    internal class Program
    {
        private static BigInteger Factorial(int i)
        {
            if (i == 1) return 1;
            var result = Factorial(i - 1) * i;
            return result;
        }

        private static BigInteger FibRec(BigInteger p1, BigInteger p2, int n)
        {
            if(p2>1) Console.Write("{0} ",p2);
            return n == 0 ? p1 : FibRec(p2, p1 + p2, n - 1);
        }

        private static BigInteger Fibonacci(int n)
        {
            return FibRec(0, 1, n);
        }


        private static void Main()
        {
            var F = new BigInteger(1);
            Console.WriteLine("Введите число:");
            var number = int.Parse(Console.ReadLine() ??
                                   throw new InvalidOperationException());

            for (var i = number; i > 1; i--) F *= i;
            Console.WriteLine("Через цикл: Факториал ({0}) = {1}", number, F);
            Console.WriteLine("Через рекурсию: Факториал ({0}) = {1}", number,
                              Factorial(number));

            Console.WriteLine("\nВведите число:");
            number = int.Parse(Console.ReadLine() ??
                               throw new InvalidOperationException());
            BigInteger first = 1;
            BigInteger second = 1;
            BigInteger sum = 0;
            Console.WriteLine("Через цикл: Ряд Фибоначчи: ");
            while (number >= sum)
            {
                sum = first + second;
                Console.Write("{0} ", sum);
                first = second;
                second = sum;
            }

            Console.WriteLine();
            Console.WriteLine("Через рекурсию: Ряд Фибоначчи: ");
            Console.Write(Fibonacci(number));
            Console.WriteLine();
        }
    }
}