using System;
using System.Text.RegularExpressions;

namespace MusicPlayer
{
    public partial class Program
    {
        /// <summary>
        ///     Values entered are limited to numbers only.
        /// </summary>
        /// <param name="str">string number</param>
        /// <param name="decimalVar">result</param>
        internal static void EnterDecimal(string str, out decimal decimalVar)
        {
            while (true)
            {
                if (str != null && Regex.IsMatch(str, "^\\d+(\\.\\d+)?$"))
                {
                    str = str.Replace('.', ',');
                    Decimal.TryParse(str, out decimalVar);
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

        internal static void EnterTime(string str, out string timeSongString)
        {
            while (true)
            {
                if (str != null &&
                    Regex.IsMatch(str,
                                  "(?:[01]\\d|2[0-3]):(?:[0-5]\\d):(?:[0-5]\\d)")
                )
                {
                    timeSongString = str;
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
    }
}