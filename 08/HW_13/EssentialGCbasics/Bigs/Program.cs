using System;
using System.Collections.Generic;
using System.Threading;

namespace Bigs
{
    internal sealed class BigObject : IDisposable
    {
        private readonly List<List<decimal>> _vs;

        private bool disposed = false;

        public BigObject()
        {
            _vs = new List<List<decimal>>();
            const int MaxCount = 800;
            const decimal Value = 1000000;
            for (var i = 0; i < MaxCount; i++)
            {
                var tmp = new List<decimal>();
                for (var j = 0; j < MaxCount; j++) tmp.Add(Value);
                _vs.Add(tmp);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    GC.WaitForPendingFinalizers();
                    Console.WriteLine("Big Object {0} was destroyed...\n", GetHashCode());
                    GC.Collect(2);
                }

                // освобождаем неуправляемые объекты
                disposed = true;
            }
        }

        ~BigObject()
        {
            for (var i = 0; i < 20; i++)
            {
                Console.Write('.');
                Thread.Sleep(150);
            }

            Console.WriteLine("\n");
            Dispose(false);
        }
    }

    internal static class Program
    {
        private static void ShowMemory()
        {
            Console.WriteLine("Available memory {0:### ### ### Kb}",
                              GC.GetTotalMemory(false) >> 10);
        }

        private static void ShowObjectInfo(object obj)
        {
            Console.WriteLine("This is the hash code of the new object: {0}",
                              obj.GetHashCode());
            Console.WriteLine("GetGeneration: {0}", GC.GetGeneration(obj));
        }

        private static void Main()
        {
            ShowMemory();

            var bigObject = new BigObject();
            ShowObjectInfo(bigObject);
            ShowMemory();

            bigObject.Dispose();
            ShowMemory();

            Console.WriteLine("*".PadRight(40, '*'));
            using (var bigObject1 = new BigObject())
            {
                ShowObjectInfo(bigObject1);
                ShowMemory();
            }

            ShowMemory();
            var bigObject2 = new BigObject();
            ShowObjectInfo(bigObject2);
            ShowMemory();

            var bigObject3 = new BigObject();
            ShowObjectInfo(bigObject3);
            ShowMemory();
        }
    }
}