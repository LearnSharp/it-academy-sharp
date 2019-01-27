using System;
using System.Collections.Generic;

namespace Palindrome
{
    internal class Program
    {
        public static string Word = "аргентина манит негра";
        public static string Word1 = "ароза упала на лапу азора";

        private static void Main()
        {
            Console.WriteLine(Word);

            var stack = new Stack<char>();
            var queue = new Queue<int>();
            var lengthPalindrome = 0; // length of palindrome under investigation
            foreach (var ch in Word1)
            {
                lengthPalindrome++;
                if (ch != ' ') stack.Push(ch);
                else queue.Enqueue(lengthPalindrome);
            }

            var str = "";
            for (var j = 1; j < lengthPalindrome + 1; j++)
            {
                if (queue.Count > 0 && j == queue.Peek())
                {
                    queue.Dequeue();
                    str += " ";
                    j++;
                }

                if (stack.Count > 0) str += stack.Pop();
            }

            Console.WriteLine(str);
            Console.WriteLine("****************");
        }
    }
}