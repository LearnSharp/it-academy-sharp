using System;
using System.Collections;
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

        private static void EnterTime(string str, out string timeSongString)
        {
            while (true)
            {
                if (str != null && Regex.IsMatch(str, "(?:[01]\\d|2[0-3]):(?:[0-5]\\d):(?:[0-5]\\d)"))
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


        public class Song
        {
            public string NameSong { get; set; }
            public string TimeSong { get; set; }
            public string Author { get; set; }

            public void RecordSong()
            {
                Console.WriteLine("Enter Song\n" +
                                  "".PadRight(40, '\u2500'));

                Console.Write("Song title: ");
                NameSong = Console.ReadLine();

                Console.Write("Playing time (hh:mm:ss): ");
                EnterTime(Console.ReadLine(), out var timeSongString);
                TimeSong = timeSongString;


                Console.Write("The name of the author: ");
                Author = Console.ReadLine();
            }

            public ArrayList GetPlaylistView()
            {
                return new ArrayList
                    {NameSong, TimeSong, Author};
            }
        }
    }
}