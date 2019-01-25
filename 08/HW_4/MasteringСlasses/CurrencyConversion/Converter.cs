using System;
using System.Text.RegularExpressions;

namespace CurrencyConversion
{
    internal class Converter
    {
        private static decimal SumConv;
        private static decimal ConvRate;

        /// <summary>
        ///     Вводимые значения ограничиваются только цифрами
        /// </summary>
        /// <param name="str">число в строковом виде</param>
        /// <param name="decimalVar">результат тип decimal</param>
        private static void EnterDecimal(string str, out decimal decimalVar)
        {
            while (true)
            {
                if (str != null && Regex.IsMatch(str, "^\\d+(\\.\\d+)?$"))
                {
                    str = str.Replace('.', ',');
                    decimal.TryParse(str, out decimalVar);
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
            Console.WriteLine("Enter the amount to convert (rub): ");
            var str = Console.ReadLine();
            EnterDecimal(str, out SumConv);

            Console.WriteLine("Enter the conversion rate (rub/usd): ");
            str = Console.ReadLine();
            EnterDecimal(str, out ConvRate);
        }

        private static void GetResult(out decimal result)
        {
            result = SumConv / ConvRate;
        }

        /// <summary>
        ///     Представление вывода
        /// </summary>
        private static void OutputView()
        {
            Console.WriteLine("\nCarrying out the conversion of rubles to usd.");
            GetResult(out var result);
            Console.WriteLine("The total amount received after the conversion will be:: {0:f2} usd",
                              result);
        }

        private static void Main(string[] args)
        {
            InputView();
            OutputView();
        }
    }
}