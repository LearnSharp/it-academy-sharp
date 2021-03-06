﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopException
{
    public class Shop
    {
        public Shop() => Prices = new List<Price>();
        public int Id { get; set; }
        public string ShopName { get; set; }

        private ICollection<Price> Prices { get; } // <--
    }

    public class Price
    {
        private Shop Shop { get; set; } // <--
        public int? ShopId { get; set; }

        public int Id { get; set; }
        public int ProductName { get; set; }
        public double CostOfGoods { get; set; }
    }

    internal class Program
    {
        private static IEnumerable<Price> GetPrices()
        {
            return new List<Price>
            {
                new Price
                {
                    ShopId = 1,
                    Id = 1,
                    ProductName = (int) Product.bread,
                    CostOfGoods = 10.12
                },
                new Price
                {
                    ShopId = 1,
                    Id = 2,
                    ProductName = (int) Product.crackers,
                    CostOfGoods = 12.51
                },
                new Price
                {
                    ShopId = 1,
                    Id = 3,
                    ProductName = (int) Product.kefir,
                    CostOfGoods = 2.13
                },
                new Price
                {
                    ShopId = 1,
                    Id = 4,
                    ProductName = (int) Product.capelin,
                    CostOfGoods = 14.84
                },
                new Price
                {
                    ShopId = 1,
                    Id = 5,
                    ProductName = (int) Product.perch,
                    CostOfGoods = 7.49
                },
                new Price
                {
                    ShopId = 2,
                    Id = 1,
                    ProductName = (int) Product.bread,
                    CostOfGoods = 10.12
                },
                new Price
                {
                    ShopId = 2,
                    Id = 2,
                    ProductName = (int) Product.crackers,
                    CostOfGoods = 12.51
                },
                new Price
                {
                    ShopId = 2,
                    Id = 3,
                    ProductName = (int) Product.kefir,
                    CostOfGoods = 2.13
                }
            };
        }

        private static IEnumerable<Shop> GetShops()
        {
            return new List<Shop>
            {
                new Shop {Id = 1, ShopName = "Selpo_1"},
                new Shop {Id = 2, ShopName = "Selpo_2"},
                new Shop {Id = 3, ShopName = "Selpo_3"}
            };
        }

        private static string GetValidName()
        {
            var inputShop = "";
            try
            {
                Console.Write("Enter Shop name: ");
                inputShop = Console.ReadLine();
                if (string.IsNullOrEmpty(inputShop) || inputShop.Length > 15)
                    throw new InvalidOperationException("Store name cannot " +
                                                        "be empty or more " +
                                                        "than 15 characters.");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"An exception occurred:\n {e.Message}");
                throw;
            }

            return inputShop;
        }

        private static void ShowShop(dynamic xGoods)
        {
            var i = 0;
            foreach (var item in xGoods)
                Console
                    .WriteLine(++i + ". {1} ".PadRight(14, ' ') + "\t{0}  price - {2:f}",
                               item.ShopName, (Product) item.ProductName,
                               item.CostOfGoods);
        }

        private static dynamic GetShop(IEnumerable<Price> prices,
                                       IEnumerable<Shop> shops, string inputShop)
        {
            var enumerable = shops.ToList();
            return
                from price in prices
                join shop in enumerable on price.ShopId equals shop.Id
                where shop.ShopName ==
                      enumerable.First(x => x.ShopName == inputShop).ShopName
                orderby shop.ShopName, price.CostOfGoods
                select new {shop.ShopName, price.ProductName, price.CostOfGoods};
        }

        private static void Main()
        {
        #region Goods

            Console.WriteLine("All products provided:");
            Console.WriteLine((Product) Group.dairy);
            Console.WriteLine((Product) Group.fish);
            Console.WriteLine((Product) Group.bakery);
            Console.WriteLine();

        #endregion Goods

            var inputShop = "";
            try
            {
                inputShop = GetValidName();
                ShowShop(GetShop(GetPrices(), GetShops(), inputShop));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"This Shop '{inputShop}' is missing!");
            }

            Console.WriteLine("\n \n \n");
        }

        [Flags] // bit group: 15, 240, 3840
        private enum Product
        {
            //------dairy------15
            milk = 1,
            cheese = 2,
            kefir = 4,
            butter = 8,

            //------fish-------240
            herring = 16,
            capelin = 32,
            halibut = 64,
            perch = 128,

            //------bakery-------3840
            bread = 256,
            loaf = 512,
            biscuits = 1024,
            crackers = 2048
        }

        private enum Group // name bit group
        {
            dairy = 15,
            fish = 240,
            bakery = 3840
        }
    }
}