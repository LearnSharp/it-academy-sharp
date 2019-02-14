using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceMonitoring
{
    internal static class Program
    {
        private sealed class BigObject : IDisposable
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
                        GC.WaitForPendingFinalizers();
                        Console.WriteLine("Big Object was destroyed...");
                    }

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

        private static uint EnterUint(string str)
        {
            uint uintVar = 1024;
            while (true)
            {
                if (str != null && Regex.IsMatch(str, "^\\d+?$"))
                {
                    uint.TryParse(str, out uintVar);
                }
                else
                {
                    Console.WriteLine("Error input! Please repeat enter: ");
                    str = Console.ReadLine();
                    continue;
                }

                break;
            }

            return uintVar;
        }

        private class Monitoring
        {
            private static uint _deviationLavel;

            public Monitoring()
            {
                _deviationLavel = SetValueDeviationControl();
            }

            private static uint SetValueDeviationControl()
            {
                Console.WriteLine("Enter the max value control of deviation level (byte): ");
                return EnterUint(Console.ReadLine());
            }

            public void Control()
            {
                var availableMemory = GC.GetTotalMemory(false) - _deviationLavel;
                if (availableMemory <= _deviationLavel)
                {
                    availableMemory = availableMemory < 0 ? 0 : availableMemory;
                    ShowAlarm((uint) GC.GetTotalMemory(false), (uint) availableMemory);
                }
            }

            private void ShowAlarm(uint total, uint available)
            {
                Console.WriteLine("Attention! You are approaching a given level of " +
                                  "maximum memory consumption!");
                Console.WriteLine("Available memory {0} byte, available user memory {1} byte.",
                                  total, available);
            }
        }

        private static void Main()
        {
            Console.WriteLine(GC.GetTotalMemory(false));

            var mon = new Monitoring();
            mon.Control();

            for (var i = 0; i < 10; i++)
            {
                mon.Control();
                using (new BigObject())
                {
                    Console.WriteLine(GC.GetTotalMemory(false));
                    mon.Control();
                }
            }

        }
    }
}