using System;

namespace Polymorphic
{
    /// <summary>
    ///     An example of using type inheritance from an object created using
    ///     the Singleton pattern and outputting some results through a delegate
    /// </summary>
    internal class Program
    {
        private static void Test()
        {
            Instance<Materials> instance = Rep;
            instance(Materials.Singleton("Soldering materials"));

            var sl1 = new Solder();
            sl1.Name = "POS-40";
            sl1.Quantity = 100;

            var sl2 = new Solder();
            sl2.Name = "POS-60";
            sl2.Quantity = 200;

            #region Solder

            instance(sl1);
            instance(sl2);

            var sl3 = sl1 + sl2;
            Console.WriteLine("sl3 = sl1 + sl2");
            instance(sl3);

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

            #endregion Solder

            #region Flux

            var fl1 = new Flux();
            fl1.Name = "Rosin";
            fl1.Quantity = 500;

            var fl2 = new Flux();
            fl2.Name = "Aspirin";
            fl2.Quantity = 300;

            instance(fl1);
            instance(fl2);

            var fl3 = fl1 + fl2;
            Console.WriteLine("fl3 = fl1 + fl2");
            instance(fl3);

            fl3 -= 25;
            Console.WriteLine("fl3 -= 25");
            fl3.ViewReport();

            fl3++;
            Console.WriteLine("fl3++");
            fl3.ViewReport();

            fl3 /= 10;
            Console.WriteLine("fl3 /= 25");
            fl3.ViewReport();

            fl3--;
            Console.WriteLine("fl3--");
            fl3.ViewReport();

            #endregion Flux
        }

        private static void Main()
        {
            Test();
        }

        private static void Rep<T>(T mat) where T : Materials
        {
            Console.WriteLine("".PadRight(50, '\u2500'));
            mat.ViewName();
            mat.ViewReport();
        }

        private class Materials
        {
            private static string _accountId;

            private static Materials _materials;

            protected Materials()
            {
                _accountId = _accountId ?? Guid.NewGuid().ToString();
            }

            private static string _accountId;

            public static string AccountId
            {
                return _materials ?? (_materials = new Materials {Name = name});
            }

            protected static string AccountId
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
            public new string Name { get; set; }

            public string SolderId
            {
                get => _solderId ?? Guid.NewGuid().ToString();
                private set => _solderId = value ?? Guid.NewGuid().ToString();
            }

            public int Quantity { get; set; }

            public override void ViewName()
            {
                Console.WriteLine("Solder: {0}", Name);
            }

            public override void ViewReport()
            {
                Console.WriteLine(" id({0}):\n id{2} {1}  qnt = {3}",
                                  AccountId, Name, SolderId, Quantity);
            }

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
            public new string Name { get; set; }

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

            public static Flux operator *(Flux fl_1, int val)
            {
                return new Flux
                {
                    FluxId = fl_1.FluxId,
                    Name = fl_1.Name,
                    Quantity = fl_1.Quantity * val
                };
            }

            public static Flux operator /(Flux fl_1, int val)
            {
                return new Flux
                {
                    FluxId = fl_1.FluxId,
                    Name = fl_1.Name,
                    Quantity = fl_1.Quantity / val
                };
            }

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

            public static Flux operator ++(Flux fl_1)
            {
                return new Flux
                {
                    FluxId = fl_1.FluxId,
                    Name = fl_1.Name,
                    Quantity = fl_1.Quantity + 10
                };
            }

            public static Flux operator --(Flux fl_1)
            {
                return new Flux
                {
                    FluxId = fl_1.FluxId,
                    Name = fl_1.Name,
                    Quantity = fl_1.Quantity - 10
                };
            }

            sl3--;
            Console.WriteLine("sl3--");
            sl3.ViewReport();
        }

            public override void ViewReport()
            {
                Console.WriteLine(" id({0}):\n id{2} {1}  qnt = {3}",
                                  AccountId, Name, FluxId, Quantity);
            }
        }
    }
}