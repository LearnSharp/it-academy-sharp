using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopException
{
    public class Shop
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        private ICollection<Price> Prices { get; set; }

        public Shop()
        {
            Prices = new List<Price>();
        }
    }

    public class Price
    {
        public Shop Shop { get; set; }
        public int? ShopId { get; set; }

        public int Id { get; set; }
        public int ProductName { get; set; }
        public double CostOfGoods { get; set; }
    }


    internal static class Program
    {
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

        private static void Main()
        {
        #region Goods

            Console.WriteLine("All products provided:");
            Console.WriteLine((Product) Group.dairy);
            Console.WriteLine((Product) Group.fish);
            Console.WriteLine((Product) Group.bakery);
            Console.WriteLine();

        #endregion Goods

            var prices = new List<Price>
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
                },
            };

            var shops = new List<Shop>
            {
                new Shop {Id = 1, ShopName = "Selpo_1"},
                new Shop {Id = 2, ShopName = "Selpo_2"},
                new Shop {Id = 3, ShopName = "Selpo_3"}
            };

            var xGoods =
                from price in prices
                join shop in shops on price.ShopId equals shop.Id
                //where shop.ShopName== "Selpo_1"
                orderby shop.ShopName, price.CostOfGoods
                select new {shop.ShopName, price.ProductName, price.CostOfGoods};


            foreach (var item in xGoods)
            {
                Console.WriteLine("{1}".PadRight(10, ' ') + "\t= {0} price - {2:f}",
                                  item.ShopName, (Product) item.ProductName,
                                  item.CostOfGoods);
            }
        }
    }
}