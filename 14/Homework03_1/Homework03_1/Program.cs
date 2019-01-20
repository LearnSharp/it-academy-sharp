using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework03_1
{
    /*
       Ввести с клавиатуры число n большее 0. 
       Вывести на экран все числа из диапазона от 0 до n, которые являются простыми.

       Продемонстрировать использование операторов for, break, continue.
       Изменить программу - вместо цикла for использовать цикл while.

     */

    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumberWithFor();

            Console.WriteLine("------------------------------------------");

            PrimeNumberWithWhile();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Press any key for exit.");
            Console.ReadKey();
        }

        private static void PrimeNumberWithFor()
        {
            int countOfPrime = 0;

            Console.WriteLine("____Prime Number With For____");
            Console.WriteLine("Enter integer value more than 0:");

            if (Int32.TryParse(Console.ReadLine(), out int value) && (value > 0))
            {
                Console.WriteLine($"In the range from 0 to {value} the following prime numbers:");

                for (int i = 1; i <= value; i++)
                {
                    //Проверяем, что число не является четным т.к. четное число не простое, но есть исключение число 2. 
                    if ((i == 1) || ((i % 2 == 0) && (i != 2)))
                    {
                        continue;
                    }

                    //Проверяем число на простоту и выводим его,если оно простое.
                    if ((i == 2) || IsPrimeNumber(i))
                    {
                        Console.WriteLine(i);
                        countOfPrime++;
                    }
                }

                Console.WriteLine($"Current range contains {countOfPrime} prime numbers.");
            }
            else
            {
                Console.WriteLine("You entered invalid value.");
            }
        }

        private static void PrimeNumberWithWhile()
        {
            int i = 1;
            int countOfPrime = 0;

            Console.WriteLine("____Prime Number With While____");
            Console.WriteLine("Enter integer value more than 0:");

            if (Int32.TryParse(Console.ReadLine(), out int value) && (value > 0))
            {
                Console.WriteLine($"In the range from 0 to {value} the following prime numbers:");

                while (i <= value)
                {
                    //Проверяем, что число не является четным т.к. четное число не простое, но есть исключение число 2. 
                    if ((i == 1) || ((i % 2 == 0) && (i != 2)))
                    {
                        i++;
                        continue;
                    }

                    //Проверяем число на простоту и выводим его,если оно простое.
                    if ((i == 2) || IsPrimeNumber(i))
                    {
                        Console.WriteLine(i);
                        countOfPrime++;
                    }

                    i++;
                }

                Console.WriteLine($"Current range contains {countOfPrime} prime numbers.");
            }
            else
            {
                Console.WriteLine("You entered invalid value.");
            }
        }

        private static bool IsPrimeNumber(int n)
        {
            bool result;
            int countOfDividers = 1; //Начинаем с 1 потмоучто число уже имеет один делитель (1).

            for (int q = 3; q <= n; q++)
            {
                if (n % q == 0)
                {
                    countOfDividers++;
                }

                if (countOfDividers > 2)
                {
                    break;
                }
            }

            result = countOfDividers <= 2 ? true : false;

            return result;
        }
    }
}
