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

            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(130);
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Peek());
            stack.Push(1);
            stack.Push(5);
            stack.Push(3);
            stack.Pop();
            stack.Peek();
            Console.WriteLine(stack.Top);
            foreach (var ammo in stack) Console.WriteLine(" - " + ammo);
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
            private T[] StackArray { get; set; }

            /// <summary>
            ///     Constructor. Create a stack.
            /// </summary>
            /// <param name="size">Stack size</param>
            public Stack(int size)
            {
                Size = size;
                Top = 0;
                StackArray = new T[Size];
            }

            private static int Capacity { get; set; } = 10;

            public Stack()
            {
                Size = Capacity;
                Top = 0;
                StackArray = new T[Size];
            }

            /// <summary>
            ///     Top Stack Marker
            /// </summary>
            public int Top { get; private set; }

            /// <summary>
            ///     Stack Size
            /// </summary>
            private int Size { get; set; }

            /// <summary>
            ///     Number of stack items
            /// </summary>
            public int Count
            {
                get => Top;
                set => Top = value;
            }

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
                    ResizeArray(StackArray);

                StackArray[Top++] = element;
            }

            private static void ResizeArray(T[] array) =>
                Array.Resize(ref array, Capacity);

            /// <summary>
            ///     Return top item
            /// </summary>
            /// <returns>Item</returns>
            public T Peek()
            {
                return StackArray[Top - 1];
            }

            /// <summary>
            ///     Reading the top of the stack
            /// </summary>
            /// <returns>Item</returns>
            public T Pop() => StackArray[--Top];

            public IEnumerator<T> GetEnumerator()
            {
                if (IsEmpty())
                    throw new Exception("Stack not filled.");

                for (var i = Top; i > 0; i--)
                    yield return StackArray[i - 1];
            }
        }
    }
}