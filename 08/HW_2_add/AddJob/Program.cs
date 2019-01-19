using System;

namespace AddJob
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            byte number;

            for (byte i = 0; i <= 25; i++)
            {
                number = i;
                Console.WriteLine("Original number: " + number);
                number = (byte)(number & byte.MaxValue - 1);
                Console.WriteLine("Number after resetting low-order bit: {0}\n",
                                  number);
            }

            //***********************************************************
            number = 16;

            // Multiply by 2
            var result = (byte)(number << 1);
            Console.WriteLine("{0} * 2 = {1}", number, result);

            // Multiply by 4
            result = (byte)(number << 2);
            Console.WriteLine("{0} * 4 = {1}", number, result);

            // Divide by 2
            result = (byte)(number >> 1);
            Console.WriteLine("{0} / 2 = {1}", number, result);

            // Divide by 4
            result = (byte)(number >> 2);
            Console.WriteLine("{0} / 4 = {1}", number, result);


            //***********************************************************
            // the value of the mantissa depends on the national language
            // environment used and the compiler settings

            var x = (double) (0.3 / 0.2);
            Console.WriteLine(0.3 / 0.2);               // 1.5 ))
            Console.WriteLine("0.3 / 0.2 = {0:f7}", x); //1,5000000

            Console.WriteLine(167.32 - 167.00); // 0,319999999999993
            double y = 167.32 - 167.00;
            Console.WriteLine("{0:f7}", y); // 0,3200000

        }
    }
}