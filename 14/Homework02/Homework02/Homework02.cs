using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework02
{
    class Homework02
    {
        static void Main(string[] args)
        {
            while(true)
            {
                decimal amount;
                decimal percent;
                decimal monthlyPayment;
                decimal fullPayment;
                decimal outstandingAmount;
                decimal monthlyPrincipal;
                string decide;
                DateTime startPeriod;
                DateTime endPeriod;


                Console.WriteLine("Enter loan amount:");

                if(Decimal.TryParse(Console.ReadLine(), out outstandingAmount) && outstandingAmount > 0)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Enter loan percent, %:");

                    if(Decimal.TryParse(Console.ReadLine(), out percent) && percent >= 0)
                    {
                        Console.WriteLine("--------------------------------");

                        fullPayment = 0;
                        monthlyPrincipal = Math.Round(outstandingAmount / 12, 2);

                        startPeriod = DateTime.Now.Date;
                        endPeriod = startPeriod.AddMonths(1);
                        
                        for (int i = 1; i <= 12; i++)
                        {
                            if (i != 12)
                            {
                                monthlyPayment = Math.Round(outstandingAmount * (percent / 100) / 365 * (endPeriod - startPeriod).Days, 2) + monthlyPrincipal;
                                fullPayment += monthlyPayment;
                                outstandingAmount -= monthlyPrincipal;
                            }
                            else
                            {
                                //Для 12го месяца берем остаток от кредита т.к. monthlyPrincipal может быть как меньше,
                                // так и больше ввиду округления и поэтому за последний месяц начисляем проценты исходя из остатка.
                                monthlyPayment = Math.Round(outstandingAmount * (percent / 100) / 365 * (endPeriod - startPeriod).Days, 2) + outstandingAmount;
                                fullPayment += monthlyPayment;
                                outstandingAmount -= monthlyPrincipal;
                            }                            

                            Console.WriteLine($"{i} month, Payment Date - {endPeriod.ToShortDateString()} - {monthlyPayment}  BYN");

                            startPeriod = endPeriod;
                            endPeriod = startPeriod.AddMonths(1);
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Full payment - {fullPayment} BYN");
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Invalid value! Enter value >= 0.");
                        Console.WriteLine("-------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Invalid value! Enter value > 0.");
                    Console.WriteLine("-------------------------------");
                }

                Console.WriteLine("-------------------------------");
                Console.WriteLine("Calculating has been finished. Enter any key for continue or 'quit' for exit.");
                Console.WriteLine("-------------------------------");
                decide = Convert.ToString(Console.ReadLine());

                if(decide.Equals("quit"))
                {
                    break;
                }
                
            }
        }

    }
}
