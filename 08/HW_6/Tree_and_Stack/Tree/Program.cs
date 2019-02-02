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

        public void Traverse(Action<int, T> visitor)
        {
            Traverse(0, visitor);
        }

        public virtual void Traverse(Action<T> visitor)
        {
            visitor((T) this);
            foreach (var child in Children)
                child.Traverse(visitor);
        }

        public virtual void Traverse(DateTime year, Action<DateTime, T> visitor)
        {
            visitor(year, (T) this);
            foreach (var child in Children)
                child.Traverse(year, visitor);
        }

        protected virtual void Traverse(int depth, Action<int, T> visitor)
        {
            visitor(depth, (T) this);
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

        private static void NodeFinder(DateTime year, GenericTreeNext node)
        {
            if (node.DateOfBirth.Year == year.Year)
                Console.WriteLine("{0}{1} ({2})", "".PadRight(3, ' '),
                                  node.Name, node.DateOfBirth.Year);
        }

        private static void AllNode(GenericTreeNext node)
        {
            Console.WriteLine("{0}{1} ({2})", "".PadRight(3, ' '),
                              node.Name, node.DateOfBirth.Year);
        }


        private static void Main()
        {
            // make 1 root of tree
            var Ivan = new GenericTreeNext("Ivan", Convert.ToDateTime("01.01.1940"));

            var Ivan1 = new GenericTreeNext("Ivan1", Convert.ToDateTime("01.01.1962"));
            Ivan.AddChild(Ivan1);

            var Ivan2 = new GenericTreeNext("Ivan2", Convert.ToDateTime("01.01.1990"));
            Ivan1.AddChild(Ivan2);

            var Ivan3 = new GenericTreeNext("Ivan3", Convert.ToDateTime("01.01.2019"));
            Ivan2.AddChild(Ivan3);

            var Stepan1 = new GenericTreeNext("Stepan1", Convert.ToDateTime("01.01.1970"));
            Ivan.AddChild(Stepan1);

            var Stepan2 = new GenericTreeNext("Stepan2", Convert.ToDateTime("01.01.2000"));
            Stepan1.AddChild(Stepan2);

            var Stepan3 = new GenericTreeNext("Stepan3", Convert.ToDateTime("01.01.2019"));
            Stepan2.AddChild(Stepan3);

            // Listing all the components (the names of relatives)
            Ivan.Traverse(AllNode);
            Console.WriteLine();

            // Output of all nodes
            Ivan.Traverse(NodeWorker);
            Console.WriteLine();

            // Deletion of an intermediate node
            // (limited access to the entire subsequent branch)
            Ivan.RemoveChild(Stepan1);
            Ivan.Traverse(NodeWorker);
            Console.WriteLine();

            // Restoration of the intermediate node
            // (full access to the entire subsequent branch)
            Ivan.AddChild(Stepan1);
            Ivan.Traverse(NodeWorker);
            Console.WriteLine();

            // Outputting a branch starting from the specified node
            Stepan1.Traverse(NodeWorker);
            Console.WriteLine();

            // Selection of relatives by year of birth
            Console.WriteLine("Selection of relatives by year of birth.");
            Ivan.Traverse(Convert.ToDateTime("01.01.2019"), NodeFinder);
            Console.WriteLine();
        }
    }
}