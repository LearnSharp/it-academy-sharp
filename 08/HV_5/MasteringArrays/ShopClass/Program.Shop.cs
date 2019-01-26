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

            public void GetArticles()
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
        }
    }
}