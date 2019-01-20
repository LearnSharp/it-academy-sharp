using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HW2
{
    class Program { 

    public double InputParam()
        {
            double param = 0;
            bool bl = true;
            while (bl) {
                WriteLine("Input number : ");
                try
                {
                    param = Math.Abs(Convert.ToDouble(ReadLine()));
                    param = Math.Truncate(param);
                    bl = false;
                }
                catch (FormatException) {
                    WriteLine("Wrong input! Try again!");
                }
            }
            WriteLine("All prime numbers from 0 to  " + param + " are: ");
            return param;
        }
    public bool IsPrime(double param) {

            for (int i = 2; i <= (int)(param/2); i++)
            {
                if (param % i == 0) {
                    return false;
                }
            }
            return true;
        }
    public void GetPrime(double param) {
            for (int i = 2; i <= param; i++)
            {
                if (IsPrime(i)) Write(i + " - ");
            }
        }

    static void Main(string[] args)
        {
            Program p = new Program();
            double par = p.InputParam();
            p.GetPrime(par);
            ReadLine();
        }
    }
}
