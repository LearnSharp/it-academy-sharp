using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HW2
{
    class Program
    {
        public decimal InputCreditSumm ()
        {
            decimal credit_summ = 0;
            bool bl = true;
            while (bl)
            {
                WriteLine("Введите сумму кредита: ");
                try
                {
                    credit_summ = Convert.ToDecimal(ReadLine());
                    bl = false;
                }
                catch (FormatException )
                {
                    WriteLine("Wrong input! Try again! ");
                }
            }
            return credit_summ;
        }

        public int InputMonth()
        {
            int month = 0;
            bool bl = true;
            while (bl)
            {
                WriteLine("ВВедите колличество месяцев:  ");
                try
                {
                    month = Convert.ToInt32(ReadLine());
                    bl = false;
                }
                catch (FormatException)
                {
                    WriteLine("Wrong input! Try again! ");
                }
            }
            return month;
        }
        public decimal InputPercent()
        {
            decimal percent = 0;
            bool bl = true;
            while (bl)
            {
                WriteLine("Введите процент:  ");
                try
                {
                    percent = Convert.ToDecimal(ReadLine());
                    bl = false;
                }
                catch (Exception)
                {
                    WriteLine("Wrong input! Try again! ");
                }
            }
            return percent;
        }
        public decimal CalculateCreditBody(decimal credit_summ , int month )
        {
            return credit_summ / month; 
        }
        public decimal CalculateAllMonth(decimal credit_summ ,decimal credit_body, int month, decimal percent)
        {
            int current_year = 2019;
            int count_of_year = month / 12;
            int count_of_month_in_last_year = month % 12;
            int summ_of_month = 0;

            decimal summ_of_all_credit = credit_summ;
            decimal every_month_pay = 0;



            decimal credit_at_finish = credit_body;
            for (int j=0; j<= count_of_year; j++)
            {
                
                if (j != count_of_year)
                {
                    
                    for (int i = 1; i <= 12; i++)
                    {
                        int days_in_month = DateTime.DaysInMonth(current_year+j, i);
                        every_month_pay = (credit_summ * percent * 0.01m) / (365 * days_in_month) + credit_body;
                        credit_summ = credit_summ - credit_body;
                        credit_at_finish += every_month_pay;
                        
                        summ_of_month = (j * 12) + i;
                        WriteLine("Выплата по " + summ_of_month + " месяцу " + " составляет " + every_month_pay );
                    }
                }
                else if (j == count_of_year)
                {
                    for (int i = 1; i <= count_of_month_in_last_year; i++)
                    {
                        int days_in_month = DateTime.DaysInMonth(current_year, i);
                        every_month_pay = (credit_summ * percent * 0.01m) / (365 * days_in_month) + credit_body;
                        credit_summ = credit_summ - credit_body;
                        credit_at_finish += every_month_pay;
                        
                        summ_of_month = (j * 12) + i;
                        WriteLine("Выплата по " + summ_of_month + " месяцу " + " составляет " + every_month_pay);
                    }
                    
                }
                
                                
            }
            WriteLine("Общая сумма выплат :" + credit_at_finish);
            return credit_at_finish;
        }

        static void Main(string[] args)
        {            
            Program p = new Program();
            decimal credit_summ = p.InputCreditSumm();
            decimal percent =  p.InputPercent();
            int month = p.InputMonth();
            decimal credit_body = p.CalculateCreditBody(credit_summ,month);
            p.CalculateAllMonth(credit_summ,credit_body,month,percent);
            ReadKey();
            
        }
    }
}
