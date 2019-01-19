using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Decimal;

namespace LoanCalculator
{
    class Program
    {
        private static int[][] months;
        private static int day;

        //private enum MonthsNames
        //{
        //    January,
        //    February,
        //    March,
        //    April,
        //    May,
        //    June,
        //    July,
        //    August,
        //    September,
        //    October,
        //    November,
        //    December
        //}

        private static decimal[] monthlyInterestPayableArray = new decimal[12];


        private static string[] monthNames =
            CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

        public static void ColRow()
        {
            months = new int[12][];
            for (var i = 0; i < 12; i++)
            {
                switch (i)
                {
                    case 0:
                        months[i] = new int[31];
                        break;
                    case 1:
                        months[i] =
                            new int[28]; //This may not always be true...  Leap Year every 4 years
                        break;
                    case 2:
                        months[i] = new int[31];
                        break;
                    case 3:
                        months[i] = new int[30];
                        break;
                    case 4:
                        months[i] = new int[31];
                        break;
                    case 5:
                        months[i] = new int[30];
                        break;
                    case 6:
                        months[i] = new int[31];
                        break;
                    case 7:
                        months[i] = new int[31];
                        break;
                    case 8:
                        months[i] = new int[30];
                        break;
                    case 9:
                        months[i] = new int[31];
                        break;
                    case 10:
                        months[i] = new int[30];
                        break;
                    case 11:
                        months[i] = new int[31];
                        break;
                }
            }

            var dayInYear = 1;
            for (var thisMonth = 0; thisMonth < months.Count(); thisMonth++)
            {
                for (day = 0; day < months[thisMonth].Count(); day++)
                {
                    months[thisMonth][day] = dayInYear;
                    dayInYear++;
                }
            }
        }


        //private static MonthsNames CurrentMonth = MonthsNames.January;

        private static decimal LoanAmount = 0;
        private static decimal LoanInterest = 0;

        private static decimal TotalAmount = 0;

        /// <summary>
        /// Вводимые значения ограничиваются только цифрами
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
        /// Представление ввода
        /// </summary>
        private static void InputView()
        {
            Console.WriteLine("Enter loan amount: ");
            var str = Console.ReadLine();
            EnterDecimal(str, out LoanAmount);

            Console.WriteLine("Enter loan interest: ");
            str = Console.ReadLine();
            EnterDecimal(str, out LoanInterest);
        }

        /// <summary>
        /// Представление вывода
        /// </summary>
        private static void OutputView()
        {
            Console.WriteLine("Monthly Payments:");
            var iter = 0;
            foreach (var monthlyInterestPayable in monthlyInterestPayableArray)
            {
                Console.WriteLine(monthNames[iter++] + "\t\t{0:f2}",
                                  monthlyInterestPayable);
                TotalAmount += monthlyInterestPayable;
            }

            Console.WriteLine("The total amount of payments will be: {0:f2} rub",
                              TotalAmount);
        }

        /// <summary>
        /// Контроллер бизнес логики приложения
        /// </summary>
        private static void LogicController()
        {
            InputView();
            ColRow();

            decimal loanBody =
                LoanAmount / monthNames.Count();

            for (int i = 0; i < 12; i++)
            {
                monthlyInterestPayableArray[i] =
                    (LoanAmount - loanBody) * LoanInterest / 365 *
                    months[i].Count();
            }

            OutputView();
        }

        private static void Main(string[] args)
        {
            LogicController();
        }
    }
}