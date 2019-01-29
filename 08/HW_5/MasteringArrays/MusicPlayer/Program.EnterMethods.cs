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

        internal static string GetInputTimeToString()
        {
            var str = "";
            const int Pos = 6;
            var cnt = 0;
            var bk = 0;

            while (cnt != Pos)
            {
                var isDigit = false;
                while (!isDigit)
                {
                    var pressedKey = Console.ReadKey();
                    if (char.IsDigit(pressedKey.KeyChar))
                    {
                        isDigit = true;
                        str += pressedKey.KeyChar.ToString();
                        cnt++;
                        if (cnt % 2 != 0) continue;
                        Console.Write(":");
                        str += ":";
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

            return "\n " + str;
        }

        internal static void EnterTime(out string timeSongString)
        {
            var str = GetInputTimeToString();

            while (true)
            {
                if (str != null &&
                    Regex.IsMatch(str,
                                  "(?:[01]\\d|2[0-3]):(?:[0-5]\\d):(?:[0-5]\\d)")
                )
                {
                    timeSongString = str.Substring(0,8);
                }
                else
                {
                    Console.WriteLine("\rError input! Please repeat enter: ");
                    str = GetInputTimeToString().Trim();
                    continue;
                }

                break;
            }
        }

        internal static void ProgressPlay(string nameSong,
                                          string timeSongString)
        {
            using (var progress = new ProgressBar())
            {
                Console.WriteLine("Playing composition:\n" + nameSong + " ");
                var timeSong = Convert.ToDateTime(timeSongString);
                var longSong = timeSong.Hour * 3600 + timeSong.Minute * 60 +
                               timeSong.Second;
                Console.WriteLine(" long Song = {0} sec.", longSong);
                var i = 0;
                while (i++ <= longSong)
                {
                    progress.Report((double) i / longSong);
                    Thread.Sleep(1000);
                }

                progress.WriteLine(" .. Done.\n");
            }
        }
    }
}