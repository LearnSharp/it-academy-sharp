using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    internal class Program
    {
        private static void Main()
        {
            Console.Title = "Custom simple Stack in native C#";

            var s = new Stack<string>(5);
            const string ctr = " ammo";
            Console.WriteLine("Charge ammunition to the store: 1, 2, 3...");
            s.Push("first" + ctr);
            s.Push("second" + ctr);
            s.Push("third" + ctr);
            Console.WriteLine("Total ammunition in the store: " + s.Count);
            Console.WriteLine();

            Console.WriteLine("Make a shot: " + s.Pop());
            Console.WriteLine("Make a shot: " + s.Pop());
            Console.WriteLine("See which cartridge is next: " + s.Peek());
            Console.WriteLine("Total ammunition in the store: " + s.Count);
            Console.WriteLine();

            Console.WriteLine("Charge more ammo: 4, 5...");
            s.Push("fifth " + ctr);
            s.Push("sixth " + ctr);
            Console.WriteLine("Total ammunition in the store: " + s.Count);
            Console.WriteLine();

            Console.WriteLine("Remaining after firing ammo:");
            foreach (var ammo in s) Console.WriteLine(" - " + ammo);

            Console.WriteLine();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Implementing a stack using a C # array.
        ///     A simple example of the implementation of
        ///     a data structure stack using native C # language features
        /// </summary>
        /// <typeparam name="T">Type of information stored</typeparam>
        internal class Stack<T> : IEnumerable
        {
            private readonly T[] Array;

            /// <summary>
            ///     Constructor. Create a stack.
            /// </summary>
            /// <param name="size">Stack size</param>
            public Stack(int size)
            {
                Size = size;
                Top = 0;
                Array = new T[Size];
            }

            /// <summary>
            ///     Top Stack Marker
            /// </summary>
            public int Top { get; private set; }

            /// <summary>
            ///     Stack Size
            /// </summary>
            public int Size { get; }

            /// <summary>
            ///     Number of stack items
            /// </summary>
            public int Count => Top;

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <summary>
            ///     Check if the stack is full
            /// </summary>
            /// <returns></returns>
            public bool IsFull() => Top == Size;

            /// <summary>
            ///     Check if the stack is empty
            /// </summary>
            /// <returns></returns>
            public bool IsEmpty() => Top == 0;

            /// <summary>
            ///     Add item to stack
            /// </summary>
            /// <param name="element">Item</param>
            public void Push(T element)
            {
                if (IsFull())
                    throw new Exception();

                Array[Top++] = element;
            }

            /// <summary>
            ///     Return top item
            /// </summary>
            /// <returns>Item</returns>
            public T Peek()
            {
                return Array[Top - 1];
            }

            /// <summary>
            ///     Reading the top of the stack
            /// </summary>
            /// <returns>Item</returns>
            public T Pop() => Array[--Top];

            public IEnumerator<T> GetEnumerator()
            {
                if (IsEmpty())
                    throw new Exception("Stack not filled.");

                for (var i = Top; i > 0; i--)
                    yield return Array[i - 1];
            }
        }
    }
}