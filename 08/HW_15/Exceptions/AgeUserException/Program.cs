using System;

namespace AgeUserException
{
    internal class PersonException : ArgumentException
    {
        public PersonException(string message, int val)
            : base(message) => Value = val;

        public int Value { get; }
    }

    internal class Person
    {
        private int _age;

        public Person(int age, string name)
        {
            Age = age == 0 ? age / age : age;
            Name = name;
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 18 || value > 95)
                    throw new PersonException(
                                              "Unfortunately, persons under " +
                                              "18 and over 95 are not allowed..",
                                              value);
                _age = value;
            }
        }

        public string Name { get; }

        public void ShowPerson()
        {
            Console.WriteLine($"{Name} is {Age} old.");
        }
    }

    internal class Program
    {
        private static void Main()
        {
            try
            {
                var person = new Person(19, "Tommy");
                person.ShowPerson();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: incorrect age is 0 years");
            }
            catch (PersonException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Incorrect value: age is {ex.Value} years");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }


            Console.WriteLine("\n \n \n");
        }
    }
}