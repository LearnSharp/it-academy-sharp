using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsObserver
{
    // Declare how a method must look in order to be used as an event handler.
    public delegate void ValueChangedHandler(Notifier sender, int cat,
                                             string oldValue, string newValue);

    public abstract class Categories
    {
        public Dictionary<int, string> CatList { get; set; }
    }

    public class Notifier : Categories
    {
        private int _numCategory;
        private string value = "";

        public Notifier(string name)
        {
            Name = name;
            CatList = new Dictionary<int, string>
            {
                [1] = "News", [2] = "Weather", [3] = "Sports",
                [4] = "Incidents", [5] = "Humor"
            };
        }

        public string Name { get; }
        public event ValueChangedHandler ValueChanged;

        private int GetNumberCategory() => _numCategory;

        private bool SetNumberCategory(int cat)
        {
            if (CatList.Keys.Contains(cat))
            {
                _numCategory = cat;
                return true;
            }

            return false;
        }

        public void ChangeValue(int cat, string newValue)
        {
            // Check if value really changes.
            if (value != newValue && SetNumberCategory(cat))
            {
                // Safe the old value.
                var oldValue = value;

                value = newValue;
                OnValueChanged(cat, oldValue, newValue);
            }
        }

        // Raises the ValueChanged event.
        private void OnValueChanged(int cat, string oldValue, string newValue)
        {
            var valueChangedHandler = ValueChanged;
            valueChangedHandler?.Invoke(this, cat, oldValue, newValue);
        }
    }

    public class Observer
    {
        // Constructor with an instance name.
        public Observer(string name) => Name = name;

        private string Name { get; }

        // The method to be registered as event handler.
        public void NotifierValueChanged(Notifier sender, int cat, string oldValue,
                                         string newValue)
        {
            Console.WriteLine($"\n{Name}: \n" +
                              $"[{sender.CatList[cat]}] -> {sender.Name} has changed\n" +
                              $"\tfrom: {oldValue} \n\tto: {newValue}");
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            // Create two notifiers - NY Times and Sovetskaya Belorussia.
            var notifierA = new Notifier("NY Times");
            var notifierB = new Notifier("Newspaper Sovetskaya Belorussia");

            // Create two observers - John Dow and Kid from Chizhovka.
            var observerX = new Observer("John Dow");
            var observerY = new Observer("Kid from Chizhovka");

            // John Dow subscribes the ValueChanged() event of NY Times.
            notifierA.ValueChanged += observerX.NotifierValueChanged;

            // Kid from Chizhovka subscribes the ValueChanged()
            // event of NY Times and Sovetskaya Belorussia.
            notifierA.ValueChanged += observerY.NotifierValueChanged;
            notifierB.ValueChanged += observerY.NotifierValueChanged;

            // Change the value of NY Times - this will notify John Dow and Kid from Chizhovka.
            notifierA.ChangeValue(4, "Snow fell all over America!");

            // Change the value of Sovetskaya Belorussia - this will only notify Kid from Chizhovka.
            notifierB.ChangeValue(1, "Prices for housing have risen sharply in Belarus.");

            // Change the value of NY Times - this will notify John Dow and Kid from Chizhovka.
            notifierA.ChangeValue(1, "All of America is suddenly moving to Belarus!");

            Console.WriteLine("\n \n \n");
        }
    }
}