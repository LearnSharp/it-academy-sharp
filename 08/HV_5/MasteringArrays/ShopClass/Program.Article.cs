using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace ShopClass
{
    internal partial class Program
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

        private class Article
        {
            private string ProductName { get; set; }

            /// <summary>
            ///     The name of the store where the product is sold
            /// </summary>
            private string StoreName { get; set; }

            /// <summary>
            ///     Cost of goods in BYN
            /// </summary>
            private decimal Cost { get; set; }

            public void CreateArticle()
            {
                Console.WriteLine("Enter Article\n" +
                                  "".PadRight(40, '\u2500'));

                Console.Write("Product Name: ");
                ProductName = Console.ReadLine();

                Console.Write("The name of the store: ");
                StoreName = Console.ReadLine();

                Console.Write("Cost of goods (BYN): ");
                EnterDecimal(Console.ReadLine(), out var cost);
                Cost = cost;
            }

            public ArrayList GetArticleView()
            {
                return new ArrayList
                    {StoreName, ProductName, Cost};
            }
        }
    }
}