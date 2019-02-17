using System;

namespace ClassException
{
    internal class MyExceptionA : Exception
    {
        public MyExceptionA(string message)
            : base(message)
        {
            Console.WriteLine("work MyExceptionA");
        }
    }

    internal class MyExceptionB : MyExceptionA
    {
        public MyExceptionB(string message)
            : base(message)
        {
            Console.WriteLine("work MyExceptionB");
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            // for a demo, please enter a string of 7 characters
            Console.Write("Enter line: ");
            var message = Console.ReadLine();
            try
            {
                try
                {
                    if (string.IsNullOrEmpty(message) || message.Length > 6)
                        throw new MyExceptionB("Line length 0 or more than 6 characters\n" +
                                               " - was worked MyExceptionB");
                }
                catch (MyExceptionB e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                catch (MyExceptionA e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
                try
                {
                    if (message != null && message.Length == 7)
                        throw new ArgumentException("String length = 7 characters..");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Finishing: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            Console.WriteLine("\n \nAll's right with the world!\n");
        }
    }
}