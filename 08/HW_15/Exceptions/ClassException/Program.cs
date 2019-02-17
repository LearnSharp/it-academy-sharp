using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassException
{

    internal class ShopException : InvalidOperationException //ArgumentException
    {
        public ShopException(string message, string val)
            : base(message) => Value = val;

        public string Value { get; }
    }

    internal static class Program
    {
        private static void Main()
        {

        }
    }
}
