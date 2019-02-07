using System;

namespace Polymorphic
{
    internal class Program
    {
        private class Materials
        {
            static Materials()
            {
                _accountId = _accountId ?? Guid.NewGuid().ToString();
            }

            private static string _accountId;

            public static string AccountId
            {
                get => _accountId;
                set => _accountId = value ?? Guid.NewGuid().ToString();
            }

            public string Name { get; set; }

            public virtual void ViewName()
            {
                Console.WriteLine("Material: {0}\n{1}", Name, AccountId);
            }

            public virtual void ViewReport()
            {
                Console.WriteLine("***** Report *****");
            }
        }

        private class Solder : Materials
        {
            private string _solderId;

            public string SolderId
            {
                get => _solderId ?? Guid.NewGuid().ToString();
                private set => _solderId = value ?? Guid.NewGuid().ToString();
            }

            public override void ViewName()
            {
                Console.WriteLine("Solder: {0}", Name);
            }

            public override void ViewReport()
            {
                Console.WriteLine(" id({0}):\n id{2} {1}  qnt = {3}",
                                  AccountId, Name, SolderId, Quantity);
            }

            public int Quantity { get; set; }

            public static Solder operator +(Solder sl_1, Solder sl_2)
            {
                return new Solder
                {
                    SolderId = Guid.NewGuid().ToString(),
                    Name = sl_1.Name + "+" + sl_2.Name,
                    Quantity = sl_1.Quantity + sl_2.Quantity
                };
            }

            public static Solder operator +(Solder sl_1, int val)
            {
                var solder = new Solder
                {
                    SolderId = sl_1.SolderId,
                    Name = sl_1.Name,
                    Quantity = sl_1.Quantity + val
                };
                return solder;
            }

            public static Solder operator *(Solder sl_1, int val)
            {
                return new Solder
                {
                    SolderId = sl_1.SolderId,
                    Name = sl_1.Name,
                    Quantity = sl_1.Quantity * val
                };
            }

            public static Solder operator /(Solder sl_1, int val)
            {
                return new Solder
                {
                    SolderId = sl_1.SolderId,
                    Name = sl_1.Name,
                    Quantity = sl_1.Quantity / val
                };
            }

            public static Solder operator -(Solder sl_1, int val)
            {
                return new Solder
                {
                    SolderId = sl_1.SolderId,
                    Name = sl_1.Name,
                    Quantity = sl_1.Quantity - val
                };
            }

            public static Solder operator ++(Solder sl_1)
            {
                return new Solder
                {
                    SolderId = sl_1.SolderId,
                    Name = sl_1.Name,
                    Quantity = sl_1.Quantity + 10
                };
            }

            public static Solder operator --(Solder sl_1)
            {
                return new Solder
                {
                    SolderId = sl_1.SolderId,
                    Name = sl_1.Name,
                    Quantity = sl_1.Quantity - 10
                };
            }
        }

        private class Flux : Materials
        {
            private string _fluxId;

            public string FluxId
            {
                get => _fluxId ?? Guid.NewGuid().ToString();
                set => _fluxId = value ?? Guid.NewGuid().ToString();
            }

            public int Quantity { get; set; }
        }

        private static void Test()
        {
            var mat1 = new Materials();
            mat1.Name = "Solder";
            mat1.ViewName();
            mat1.ViewReport();

            var sl1 = new Solder();
            sl1.Name = "POS-40";
            sl1.Quantity = 100;

            var sl2 = new Solder();
            sl2.Name = "POS-60";
            sl2.Quantity = 200;

            Console.WriteLine("".PadRight(50, '\u2500'));

            sl1.ViewName();
            sl1.ViewReport();

            Console.WriteLine("".PadRight(50, '\u2500'));

            sl2.ViewName();
            sl2.ViewReport();

            Console.WriteLine("".PadRight(50, '\u2500'));

            var sl3 = sl1 + sl2;
            Console.WriteLine("sl3 = sl1 + sl2");
            sl3.ViewName();
            sl3.ViewReport();

            sl3 -= 25;
            Console.WriteLine("sl3 -= 25");
            sl3.ViewReport();

            sl3++;
            Console.WriteLine("sl3++");
            sl3.ViewReport();

            sl3 /= 10;
            Console.WriteLine("sl3 /= 25");
            sl3.ViewReport();

            sl3--;
            Console.WriteLine("sl3--");
            sl3.ViewReport();
        }

        private static void Main()
        {
            Test();
        }
    }
}