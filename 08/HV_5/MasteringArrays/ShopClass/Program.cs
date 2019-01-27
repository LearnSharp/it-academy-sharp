using System;

namespace ShopClass
{
    internal partial class Program
    {
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


            //shop.ShopAllView();
            shop.ShopFindByIndex();
            shop.ShopFindByName();
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