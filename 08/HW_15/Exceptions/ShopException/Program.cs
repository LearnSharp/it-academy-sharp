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

#region Test

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
            Console.WriteLine((Product) Group.dairy);
            Console.WriteLine((Product) Group.fish);
            Console.WriteLine((Product) Group.bakery);

        #endregion Test

            var prices = new List<Price>
            {
                new Price
                {
                    ShopId = 1, Id = 1, ProductName = (int) Product.bread,
                    CostOfGoods = 10
                },
                new Price
                {
                    ShopId = 1, Id = 2, ProductName = (int) Product.capelin,
                    CostOfGoods = 12
                },
            };

            var shops = new List<Shop>
            {
                new Shop {Id = 1, ShopName = "Selpo_1"},
                new Shop {Id = 2, ShopName = "Selpo_2"},
                new Shop {Id = 3, ShopName = "Selpo_3"}
            };
        }
    }
}