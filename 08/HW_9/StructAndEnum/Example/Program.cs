using System;

namespace Example
{
    internal struct ZipCode
    {
        // Поля

        // Конструкторы.
        public ZipCode(int fiveDigitCode, int plusFourExtension)
        {
            FiveDigitCode = fiveDigitCode;
            PlusFourExtension = plusFourExtension;
        }

        public ZipCode(int fiveDigitCode) : this(fiveDigitCode, 0)
        {
        }

        // Свойства.
        public int FiveDigitCode { get; }
        public int PlusFourExtension { get; }
    }

    internal class Program
    {
        private static void Main()
        {
            var zipCode = new ZipCode(12345, 1234);

            Console.WriteLine(zipCode.FiveDigitCode);
            Console.WriteLine(zipCode.PlusFourExtension);

            var zipCode1 = new ZipCode(12345);
            Console.WriteLine(zipCode1.FiveDigitCode);
            Console.WriteLine(zipCode1.PlusFourExtension);
        }
    }
}
