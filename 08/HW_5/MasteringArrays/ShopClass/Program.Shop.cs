using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShopClass
{
    internal partial class Program
    {
        private class Shop
        {
            public Shop()
            {
                var articles = new List<Article>();
                Articles = articles;
            }

            private List<Article> Articles { get; }

            public ArrayList GetArticleByIndex(int index)
            {
                var fnd = Articles.ElementAtOrDefault(index);
                return fnd?.GetArticleView();
            }

            public ArrayList GetArticleByName(string name)
            {
                foreach (var itm in Articles)
                    if (itm.GetArticleView().Contains(name))
                        return itm.GetArticleView();

                return null;
            }

            public void AddArticles(Article article)
            {
                Articles.Add(article);
            }

            private void GetArticles()
            {
                if (!Articles.Any()) return;
                Console.WriteLine("Introduced articles:\n"
                                      .PadRight(20, '\u2500'));
                var num = 0;
                foreach (var it in Articles)
                {
                    Console.Write("{0}  ", ++num);
                    foreach (var i in it.GetArticleView())
                        Console.Write("{0} ", i);

                    Console.WriteLine();
                }

                Console.WriteLine("\n".PadRight(20, '\u2500'));
            }

            // ReSharper disable once UnusedMember.Global
            // ReSharper disable once UnusedMember.Local
            public void ShopAllView()
            {
                Console.WriteLine("\n".PadRight(20, '\u2500'));
                GetArticles();
            }

            private static void GetItemView(IEnumerable fnd)
            {
                if (fnd == null) return;
                Console.WriteLine("\nSearch completed:\t");
                foreach (var item in fnd) Console.Write("{0} ", item);

                Console.WriteLine();
            }

            public void ShopFindByIndex()
            {
                Console.Write("Enter the product Index in the store list: ");
                EnterDecimal(Console.ReadLine(), out var num);
                var fnd = GetArticleByIndex(Convert.ToInt16(num));
                if (fnd != null) GetItemView(fnd);
                else Console.WriteLine("Search returned no results.");
            }

            public void ShopFindByName()
            {
                Console.Write("Enter the product Name in the store list: ");
                var fnd = GetArticleByName(Console.ReadLine());
                if (fnd != null) GetItemView(fnd);
                else Console.WriteLine("Search returned no results.");
            }
        }
    }
}