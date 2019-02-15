using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace ResourceMonitoring
{
    internal static class Program
    {
        private static uint SetUint(string str)
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

        private static void Main()
        {
            var mon = new Monitoring();

            for (var i = 0; i < 5; i++)
            {
                Console.Write("{0}. ", i + 1);
                using (new BigObject()) mon.Control();
            }
        }

        private sealed class BigObject : IDisposable
        {
            private readonly List<List<decimal>> _vs;

            private bool disposed = false;

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

                Console.WriteLine("This is the hash code of the new object: {0},",
                                  GetHashCode());
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
                        Console.WriteLine("Big Object {0} was destroyed...\n",
                                          GetHashCode());
                    }

                    disposed = true;
                }
            }

            ~BigObject()
            {
                Dispose(false);
            }
        }

        private class Monitoring
        {
            private static uint _deviationLavel;

            public Monitoring() => _deviationLavel = SetValueDeviationControl();

            private static uint SetValueDeviationControl()
            {
                Console.Write("Enter the max value control \nof deviation level (byte): ");
                return SetUint(Console.ReadLine());
            }

            public void Control()
            {
                var availableMemory = GC.GetTotalMemory(false) - _deviationLavel;

                if (availableMemory > _deviationLavel)
                {
                    ShowMemory((uint) GC.GetTotalMemory(false), (uint) availableMemory);
                }
                else
                {
                    availableMemory = availableMemory < 0 ? 0 : availableMemory;
                    ShowAlarm((uint) GC.GetTotalMemory(false), (uint) availableMemory);
                }
            }

            private void ShowMemory(uint total, uint available)
            {
                Console.WriteLine("Available memory {0:### ### ### Kb}, " +
                                  " available user memory {1:### ### ### Kb};",
                                  total >> 10, available >> 10);
            }

            private void ShowAlarm(uint total, uint available)
            {
                Console.WriteLine("\nAttention! You are approaching a given level of " +
                                  "maximum memory consumption!");
                ShowMemory(total, available);
            }
        }
    }
}