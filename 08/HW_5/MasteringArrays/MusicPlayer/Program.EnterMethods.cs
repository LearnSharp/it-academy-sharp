using System;
using System.Text.RegularExpressions;
using System.Threading;
using MusicPlayer.Models;

namespace MusicPlayer
{
    public partial class Program
    {
        /// <summary>
        ///     Values entered are limited to numbers only.
        /// </summary>
        /// <param name="str">string number</param>
        /// <param name="decimalVar">result</param>
        internal static void SetEnterDecimal(string str, out decimal decimalVar)
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

        internal static string SetEnterTimeToString()
        {
            var str = "";
            int bk = 0, cnt = 0, lenTemplate = "00:00:00".Length;
            var isCurrent = false;

            while (!isCurrent)
            {
                var isDigit = false;
                while (!isDigit)
                {
                    while (Console.KeyAvailable) Console.ReadKey(false);

                    var pressedKey = Console.ReadKey();
                    if (char.IsDigit(pressedKey.KeyChar))
                    {
                        isDigit = true;
                        str += pressedKey.KeyChar.ToString();
                        if (++cnt % 2 != 0) continue;
                        if (str.Length != lenTemplate)
                        {
                            str += ":";
                            Console.Write(":");
                        }
                        else
                        {
                            isCurrent = true;
                        }
                    }

                    else
                    {
                        const string err = " <- Please input a digit.\r";
                        var back = ++bk > 0
                            ? "\r ".PadRight(10, ' ') + err
                            : "";
                        Console.Write(back);
                        str = "";
                        break;
                    }
                }
            }

            return str;
        }

        internal static void SetEnterTimePlay(out string timeSongString)
        {
            var str = SetEnterTimeToString();

            while (true)
            {
                if (str != null &&
                    Regex.IsMatch(str,
                                  "(?:[01]\\d|2[0-3]):(?:[0-5]\\d):(?:[0-5]\\d)")
                )
                {
                    timeSongString = str.Substring(0, 8);
                }
                else
                {
                    Console.WriteLine("\rError input! Please repeat enter: ");
                    str = SetEnterTimeToString();
                    continue;
                }

                break;
            }
        }

    }
}