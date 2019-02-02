using System;
using System.Collections.Generic;

namespace Tree
{
    internal class GenericTree<T> where T : GenericTree<T>
        // recursive constraint  
    {
        // no specific data declaration  

        protected List<T> Children { get; }

        public GenericTree()
        {
            Children = new List<T>();
        }

        public virtual void AddChild(T newChild)
        {
            Children.Add(newChild);
        }

        public virtual void RemoveChild(T node)
        {
            Children.Remove(node);
        }

        //todo отобрать родственников по году рождения

        public void Traverse(Action<int, T> visitor)
        {
            Traverse(0, visitor);
        }

        protected virtual void Traverse(int depth, Action<int, T> visitor)
        {
            visitor(depth, (T)this);
            foreach (var child in Children)
                child.Traverse(depth + 1, visitor);
        }
    }

    internal class
        GenericTreeNext : GenericTree<GenericTreeNext> // concrete derivation
    {
        public GenericTreeNext(string name, DateTime date)
        {
            Name = name;
            DateOfBirth = date;
        }

        public string Name { get; set; } // user-data example
        public DateTime DateOfBirth { get; set; }
    }


    internal class Program
    {
        private static void NodeWorker(int depth, GenericTreeNext node)
        {
            // a little one-line string-concatenation (n-times)
            Console.WriteLine("{0}{1}: {2} ({3})",
                              string.Join("".PadRight(3, ' '), new string[depth + 1]),
                              depth, node.Name, node.DateOfBirth.Year);
        }

        private static void Main()
        {
            // make root of tree
            var Ivan = new GenericTreeNext("Ivan", Convert.ToDateTime("01.01.1940"));

            var Ivan1 = new GenericTreeNext("Ivan1", Convert.ToDateTime("01.01.1962"));
            Ivan.AddChild(Ivan1);

            var Stepan1 = new GenericTreeNext("Stepan1", Convert.ToDateTime("01.01.1970"));
            Ivan.AddChild(Stepan1);

            var Ivan2 = new GenericTreeNext("Ivan2", Convert.ToDateTime("01.01.1990"));
            Ivan1.AddChild(Ivan2);

            var Stepan2 = new GenericTreeNext("Stepan2", Convert.ToDateTime("01.01.2000"));
            Stepan1.AddChild(Stepan2);

            var Stepan3 = new GenericTreeNext("Stepan3", Convert.ToDateTime("01.01.2019"));
            Stepan2.AddChild(Stepan3);


            Ivan.Traverse(NodeWorker);
            Console.WriteLine();

            Ivan.RemoveChild(Stepan1);
            Ivan.Traverse(NodeWorker);
            Console.WriteLine();

            Ivan.AddChild(Stepan1);
            Ivan.Traverse(NodeWorker);
            Console.WriteLine();

            Stepan1.Traverse(NodeWorker);

        }
    }
}