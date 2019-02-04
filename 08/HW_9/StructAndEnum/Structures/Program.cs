using System;

namespace Structures
{
    internal struct MyStruct
    {
        public string Change { get; set; }
    }

    internal class MyClass
    {
        public string Change { get; set; }
    }

    internal class Program
    {
        public static void ClassTaker(MyClass myClass)
        {
            myClass.Change = "changed";
        }

        public static void StructTaker(MyStruct myStruct)
        {
            myStruct.Change = "changed";
        }

        public static void StructTaker(ref MyStruct myStruct)
        {
            myStruct.Change = "changed";
        }


        private static void Main()
        {
            var cls = new MyClass();
            var myStr = new MyStruct();

            cls.Change = "not changed";
            myStr.Change = "not changed";

            Console.WriteLine("On class:");
            Console.WriteLine(cls.Change);
            ClassTaker(cls);
            Console.WriteLine(cls.Change);

            Console.WriteLine();

            Console.WriteLine("On struct:");
            Console.WriteLine(myStr.Change);
            StructTaker(myStr);
            Console.WriteLine(myStr.Change);
            Console.WriteLine();

            //structure is a significant type, and class is a reference data type
            Console.WriteLine("On used ref:");
            Console.WriteLine(myStr.Change);
            StructTaker(ref myStr);
            Console.WriteLine(myStr.Change);
        }
    }
}