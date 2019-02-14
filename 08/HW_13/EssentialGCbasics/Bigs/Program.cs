using System;
using System.Collections.Generic;
//using System.Runtime;
using System.Threading;

namespace Bigs
{
    internal sealed class BigObject : IDisposable
    {
        private readonly List<List<decimal>> _vs;

        public BigObject()
        {
            _vs = new List<List<decimal>>();
            const int MaxCount = 500;
            const decimal Value = 1000000;
            for (var i = 0; i < MaxCount; i++)
            {
                var tmp = new List<decimal>();
                for (var j = 0; j < MaxCount; j++) tmp.Add(Value);
                _vs.Add(tmp);
            }
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    GC.WaitForPendingFinalizers();
                    Console.WriteLine("Big Object was destroyed...");
                }

                // освобождаем неуправляемые объекты
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BigObject()
        {
            for (var i = 0; i < 20; i++)
            {
                Console.Write('.');
                Thread.Sleep(150);
            }

            Console.WriteLine();
            Dispose(false);
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            var bigObject = new BigObject();

            Console.WriteLine(GC.GetGeneration(bigObject));
            Console.WriteLine(GC.GetTotalMemory(false));

            bigObject.Dispose();

            Console.WriteLine(GC.GetGeneration(bigObject));
            Console.WriteLine(GC.GetTotalMemory(false));
            Console.WriteLine("********************************");

            using (var bigObject1 = new BigObject())
            {
                Console.WriteLine(GC.GetGeneration(bigObject1));
                Console.WriteLine(GC.GetTotalMemory(false));
            }

            Console.WriteLine(GC.GetTotalMemory(false));
            var bigObject2 = new BigObject();
            Console.WriteLine(GC.GetTotalMemory(false));
            GC.Collect(2);
            Console.WriteLine(GC.GetTotalMemory(false));


            Console.WriteLine("\nGetGeneration:");
            Console.WriteLine(GC.GetGeneration(bigObject));
            Console.WriteLine(GC.GetGeneration(bigObject2));

            Console.WriteLine();
        }
    }
}