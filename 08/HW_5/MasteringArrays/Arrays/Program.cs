using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Arrays
{
    internal class Program
    {
        private static int Rate;

        /// <summary>
        ///     Вводимые значения ограничиваются только цифрами
        /// </summary>
        /// <param name="str">число в строковом виде</param>
        /// <param name="decimalVar">результат тип decimal</param>
        private static void EnterDimension(string str, out int decimalVar)
        {
            while (true)
            {
                if (str != null && Regex.IsMatch(str, "^\\d+(\\.\\d+)?$"))
                {
                    str = str.Replace('.', ',');
                    int.TryParse(str, out decimalVar);
                }
                else
                {
                    Console.WriteLine("Error input! Please repeat enter: ");
                    str = Console.ReadLine();
                    continue;
                }

                break;
            }
        }

        /// <summary>
        ///     Представление ввода
        /// </summary>
        private static void InputView()
        {
            Console.Write("Enter array dimension: ");
            var str = Console.ReadLine();
            EnterDimension(str, out Rate);
        }

        private static void CreateRandomDim(out int[] dim)
        {
            InputView();
            var b = new[] {5, 8, 1, 7, 3, 2, 9, 0, 4, 6};
            var d = new[] {9, 4, 7, 2, 8, 0, 5, 1, 3, 4};
            dim = new int[] { };
            Array.Resize(ref dim, dim.Length + Rate);
            for (var i = 0; i < Rate; i++)
            {
                var rnd = new Random(DateTime.Now.Millisecond);
                var str = Convert.ToString(b[rnd.Next(10)]) +
                          Convert.ToString(d[rnd.Next(10)]);
                var t = int.Parse(str);
                Thread.Sleep(5);
                Console.Write("\u2500\u2500");
                dim[i] = t;
            }

            Console.WriteLine();
        }

        private static void View(int[] dim)
        {
            foreach (var item in dim) Console.Write("{0} ", item);

            Console.WriteLine("\nMax value = {0}, Min value = {1}", dim.Max(),
                              dim.Min());
            Console.WriteLine("Sum of all array elements = {0}", dim.Sum());
            Console.WriteLine("Arithmetic average of all elements of the array = {0}",
                              dim.Average());
            Console.WriteLine("All odd array values:");
            foreach (var item in dim)
                if (item % 2 != 0)
                    Console.Write("{0} ", item);
            Console.WriteLine();
        }

        private static void Main()
        {
            CreateRandomDim(out var dim);
            View(dim);
        }
    }
}