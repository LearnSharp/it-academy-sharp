using System;
using System.Collections;

namespace MyDictionary
{
    internal class MyDictionary : IEnumerable
    {
        public MyDictionary()
        {
            Top = 0;
            Key = new string[Capacity];
            Value = new int[Capacity];
        }

        public int Capacity { get; } = 100;
        public int Top { get; set; }
        public string[] Key { get; }
        public int[] Value { get; }

        public string this[string index]
        {
            get
            {
                var id = -1;
                foreach (var t in Key)
                {
                    id++;
                    if (t == index)
                        return t + " -> " + Value[id];
                }

                return $"{index} - no translation for this word.";
            }
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < Top)
                    return Key[index] + " -> " + Value[index];
                return "Attempt to address out of range.";
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < Top; i++)
                yield return Key[i] + "\t: " + Value[i];
        }

        public void Add(string key, int value)
        {
            Key[Top] = key;
            Value[Top] = value;
            ++Top;
        }

        public int Count()
        {
            return Top;
        }
    }


    internal class Program
    {
        private static void Main()
        {
            var dict = new MyDictionary
            {
                {"zero", 0},
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9}
            };

            Console.WriteLine(" dict[\"two\"] = {0}", dict["two"]);
            Console.WriteLine(" dict[2] = {0}", dict[2]);
            Console.WriteLine();

            foreach (var it in dict) Console.WriteLine("{0}", it);
            Console.WriteLine("Count of elements: {0}", dict.Count());
            Console.WriteLine();

            var dict1 = new MyDictionary
            {
                {"zero", 0},
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4}
            };

            foreach (var it in dict1) Console.WriteLine("{0}", it);
            Console.WriteLine("Count of elements: {0}", dict1.Count());
        }
    }
}