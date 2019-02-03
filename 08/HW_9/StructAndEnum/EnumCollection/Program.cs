using System;
using static EnumType.EnumColor;

namespace EnumType
{
    internal static class EnumColor
    {
        public static void Print(string str, int color)
        {
            var itr = 0;
            var type = typeof(Colors);

            foreach (Colors enColor in Enum.GetValues(type))
            {
                if ((int) enColor == color)
                    Console.ForegroundColor = (ConsoleColor) itr;
                itr++;
            }

            Console.WriteLine("{0}", str);
        }

        internal static int MenuColor()
        {
            Console.WriteLine("Press Esc to exit.\n");
            Console.Clear();
            Console.WriteLine("Select text color");
            var type = typeof(ConsoleColor);
            var counter = 0;
            foreach (var name in Enum.GetNames(type))
            {
                Console.ForegroundColor = (ConsoleColor) Enum.Parse(type, name);
                Console.WriteLine("{0}\t{1}", counter++, name);
            }

            Console.Write("Enter color number: ");
            var chNum = (int) Console.ReadKey().KeyChar;
            var chNum1 = (int) Console.ReadKey().KeyChar;
            chNum1 = chNum1 == 13 ? 0 : chNum1;
            var ch = Convert.ToString(chNum) +
                     (chNum1 == 0 ? null : Convert.ToString(chNum1));
            Console.ResetColor();

            return Convert.ToInt32(ch);
        }

        private enum Colors
        {
            Black = 48,
            DarkBlue,
            DarkGreen,
            DarkCyan,
            DarkRed,
            DarkMagenta,
            DarkYellow,
            Gray,
            DarkGray,
            Blue,
            Green = 4948,
            Cyan,
            Red,
            Magenta,
            Yellow,
            White
        }
    }


    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                var color = MenuColor();
                Console.Write("\nEnter the word: ");
                var str = Console.ReadLine();
                Print(str, color);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}