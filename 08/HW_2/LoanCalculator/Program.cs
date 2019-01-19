using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Decimal;

namespace LoanCalculator
{
    internal class Program
    {
        private static int[][] months; // Годовой массив месяцы/дни

        private static readonly decimal[] monthlyInterestPayableArray =
            new decimal[12]; // Накопительный массив месячных выплат

        private static readonly string[] monthNames =
            CultureInfo.CurrentCulture.DateTimeFormat
                       .MonthNames; // Месяцы по именам

        private static decimal LoanAmount;   // Сумма кредита
        private static decimal LoanInterest; // Годовая процентная ставка
        private static decimal TotalAmount;  // Полные выплаты по кредиту
        private static decimal loanBody;     // Тело кредита

        /// <summary>
        ///     Создание годового массива месяцы/дни
        /// </summary>
        private static void ColRow()
        {
            months = new int[12][];
            for (var i = 0; i < 12; i++)
                if (i == 0)
                    months[i] = new int[31];
                else if (i == 1) months[i] = new int[28];
                else if (i == 2) months[i] = new int[31];
                else if (i == 3) months[i] = new int[30];
                else if (i == 4) months[i] = new int[31];
                else if (i == 5) months[i] = new int[30];
                else if (i == 6) months[i] = new int[31];
                else if (i == 7) months[i] = new int[31];
                else if (i == 8) months[i] = new int[30];
                else if (i == 9) months[i] = new int[31];
                else if (i == 10) months[i] = new int[30];
                else if (i == 11) months[i] = new int[31];

            for (int currentMonth = 0, dayInYear = 1;
                 currentMonth < months.Count();
                 currentMonth++)
            {
                for (var day = 0; day < months[currentMonth].Count(); day++)
                {
                    months[currentMonth][day] = dayInYear;
                    dayInYear++;
                }
            }
        }

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
                    //Console.WriteLine("on input received: {0}", str);
                    str = str.Replace('.', ',');
                    TryParse(str, out decimalVar);
                    //Console.WriteLine("received: {0}", decimalVar);
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
            Console.WriteLine("Enter loan amount (rub): ");
            var str = Console.ReadLine();
            EnterDecimal(str, out LoanAmount);

            Console.WriteLine("Enter loan interest (%): ");
            str = Console.ReadLine();
            EnterDecimal(str, out LoanInterest);
        }

        /// <summary>
        ///     Представление вывода дифференциальных платежей
        /// </summary>
        private static void OutputDifferentView()
        {
            Console.WriteLine("\nMonthly differentiated payments:\n");
            var iterator = 0;
            TotalAmount = 0;
            foreach (var monthlyInterestPayable in monthlyInterestPayableArray)
            {
                Console.WriteLine(monthNames[iterator++].PadRight(10)
                                  + "\t{0:f2} rub",
                                  monthlyInterestPayable + loanBody);
                TotalAmount += monthlyInterestPayable + loanBody;
            }

            Console.WriteLine("\nThe total amount of payments will be: {0:f2} rub",
                              TotalAmount);
        }

        /// <summary>
        ///     Представление вывода аннуитетных платежей
        /// </summary>
        private static void OutputAnnuityView()
        {
            Console.WriteLine("\nMonthly annuity payments:\n");

            var li = LoanInterest / 12 / 100;
            var x = Convert.ToDouble(1 + li);
            var tmp = Convert.ToDecimal(Math.Pow(x, 12));
            // ReSharper disable once ComplexConditionExpression
            var KS = li * tmp * LoanAmount / (tmp - 1);

            var iterator = 0;
            TotalAmount = 0;
            for (var i = 0; i < 12; i++)
            {
                Console.WriteLine(monthNames[iterator++].PadRight(10)
                                  + "\t{0:f2} rub", KS);
                TotalAmount += KS;
            }

            Console.WriteLine("\nThe total amount of payments will be: {0:f2} rub",
                              TotalAmount);
        }

        /// <summary>
        ///     Контроллер бизнес логики приложения
        /// </summary>
        private static void LogicController()
        {
            InputView();
            ColRow();

            loanBody =
                LoanAmount / (monthNames.Length - 1);

            var subtotal = LoanAmount;
            for (var i = 0; i < 12; i++)
            {
                var decrement = i == 0 ? 0 : loanBody;
                subtotal -= decrement;
                // ReSharper disable once ComplexConditionExpression
                monthlyInterestPayableArray[i] =
                    subtotal * (LoanInterest / 100) / 365 * months[i].Count();
            }

            OutputDifferentView();
            OutputAnnuityView();
        }

        private static void Main(string[] args)
        {
            LogicController();
        }
    }
}