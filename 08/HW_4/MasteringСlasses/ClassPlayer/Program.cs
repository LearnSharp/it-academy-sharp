using System;
using System.Diagnostics.CodeAnalysis;

namespace ClassPlayer
{
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    internal class Program
    {
        private static void Test()
        {
            var testArrayMemory = new[]
            {
                2, 12, 16, 18, 21, 28, 32, 42, 56, 64, 120, 128, 256, 480, 512
            };

            var testNameProduce = new[]
                {"", "Italy", "China", "Russia", "UK", null, "USA"};

            Console.WriteLine("*** Test var X = new Player() ***");
            var X = new Player();
            X.GetInfo();

            Console.WriteLine("\n*** Test var X = new Player(string) ***");
            foreach (var producer in testNameProduce)
            {
                var X1 = new Player(producer);
                X1.GetInfo();
            }

            Console.WriteLine("\n*** Test var X = new Player(int) ***");
            foreach (var memory in testArrayMemory)
            {
                var X1 = new Player(memory);
                if (X1.Memory != 0) X1.GetInfo();
            }

            Console.WriteLine("\n*** Test var X = new Player(string, int) ***");
            foreach (var producer in testNameProduce)
            {
                foreach (var memory in testArrayMemory)
                {
                    var X1 = new Player(producer, memory);
                    if (X1.CheckCreated) X1.GetInfo();
                }
            }
        }

        private static void Main()
        {
            Test();
        }

        private class Player
        {
            private const string NameInit = "Belarus";

            private static readonly int[] PresetValuesOfMemory =
                {16, 32, 64, 128, 256, 512};

            private int _memory;

            private string _producer;

            public Player()
            {
                _producer = NameInit;
            }

            public Player(string producer)
            {
                if (CheckInputProducer(producer)) _producer = producer;
            }


            public Player(int memory)
            {
                if (CheckInputMemory(memory)) _memory = memory;
            }

            public Player(string producer, int memory)
            {
                if (CheckInputProducer(producer)) _producer = producer;
                if (CheckInputMemory(memory)) _memory = memory;
                CheckCreated = CheckInputProducer(producer) &&
                               CheckInputMemory(memory);
            }

            public bool CheckCreated { get; }

            public string Producer
            {
                get => _producer;
                set
                {
                    if (CheckInputProducer(value)) _producer = value;
                }
            }

            public int Memory
            {
                get => _memory;
                set
                {
                    if (CheckInputMemory(value)) _memory = value;
                }
            }

            private static bool CheckInputProducer(string producer)
            {
                return producer != null;
            }

            private static bool CheckInputMemory(int memory)
            {
                return memory > 0 &&
                       Array.IndexOf(PresetValuesOfMemory, memory) != -1;
            }

            public void AlertMessage(object input)
            {
                if (!CheckCreated)
                    Console.WriteLine("The resulting value \"{0}\" is wrong",
                                      input);
            }

            public void GetInfo()
            {
                Console.WriteLine("Producer: {0}, memory = {1}", _producer,
                                  _memory);
            }
        }
    }
}