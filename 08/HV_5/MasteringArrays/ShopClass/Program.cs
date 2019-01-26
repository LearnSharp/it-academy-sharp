using System;
using System.Collections;

namespace ShopClass
{
    internal partial class Program
    {
        // ReSharper disable once UnusedMember.Local
        private static void ShopAllView(Shop shop)
        {
            Console.WriteLine("\n".PadRight(20, '\u2500'));
            shop.GetArticles();
        }

        private static void GetItemView(IEnumerable fnd)
        {
            if (fnd == null) return;
            Console.WriteLine();
            foreach (var item in fnd) Console.Write("{0} ", item);

            Console.WriteLine();
        }

        private static void ShopFindByIndex(Shop shop)
        {
            Console.Write("Enter the product Index in the store list: ");
            EnterDecimal(Console.ReadLine(), out var num);
            var fnd = shop.GetArticleByIndex(Convert.ToInt16(num));
            if (fnd != null) GetItemView(fnd);
            else Console.WriteLine("Search returned no results.");
        }

        private static void ShopFindByName(Shop shop)
        {
            Console.Write("Enter the product Name in the store list: ");
            var fnd = shop.GetArticleByName(Console.ReadLine());
            if (fnd != null) GetItemView(fnd);
            else Console.WriteLine("Search returned no results.");
        }

        private static void TradeController()
        {
            var shop = new Shop();
            ConsoleKeyInfo inp;
            do
            {
                var article = new Article();
                article.CreateArticle();
                shop.AddArticles(article);
                Console.WriteLine("\nContinue entering?\nPress any key " +
                                  "for continue or Esc for exit.\n");
                inp = Console.ReadKey(true);
            } while (inp.Key != ConsoleKey.Escape);


            //ShopAllView(shop);
            ShopFindByIndex(shop);
            ShopFindByName(shop);
        }

        /// <summary>
        ///     • display information about the product by number using the index;
        ///     • display information about the product, the name of which is entered
        ///     from the keyboard, if there are no such goods, to issue a
        ///     corresponding message;
        /// </summary>
        private static void Main()
        {
            TradeController();
        }
    }
}