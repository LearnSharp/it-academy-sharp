using System;

namespace ServiceSubscriber
{
    // Declare how a method must look in order to be used as an event handler.
    public delegate void ValueChangedHandler(Notifier sender, string oldValue,
                                             string newValue);

    public class Notifier
    {
        private string value = "";

        // Constructor with an instance name.
        public Notifier(string name) => Name = name;

        public string Name { get; }

        public event ValueChangedHandler ValueChanged;

        /// <summary>
        ///     A method that modifies the private field value and
        ///     notifies observers by raising the ValueChanged event.
        /// </summary>
        /// <param name="newValue"> if new value</param>
        public void ChangeValue(string newValue)
        {
            // Check if value really changes.
            if (value != newValue)
            {
                // Safe the old value.
                var oldValue = value;
                value = newValue;
                OnValueChanged(oldValue, newValue);
            }
        }

        // Raises the ValueChanged event.
        private void OnValueChanged(string oldValue, string newValue)
        {
            var valueChangedHandler = ValueChanged;
            valueChangedHandler?.Invoke(this, oldValue, newValue);
        }
    }

    public class Observer
    {
        // Constructor with an instance name.
        public Observer(string name) => Name = name;

        private string Name { get; }

        // The method to be registered as event handler.
        public void NotifierValueChanged(Notifier sender, string oldValue, string newValue)
        {
            Console.WriteLine($"\n{Name}: Hot news {sender.Name} has changed\n" +
                              $"\tfrom: {oldValue} \n\tto: {newValue}!!!");
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

            // Kid from Chizhovka subscribes the ValueChanged() event of NY Times and B.
            notifierA.ValueChanged += observerY.NotifierValueChanged;
            notifierB.ValueChanged += observerY.NotifierValueChanged;

            // Change the value of NY Times - this will notify John Dow and Kid from Chizhovka.
            notifierA.ChangeValue("Snow fell all over America!");

            // Change the value of Sovetskaya Belorussia - this will only notify Kid from Chizhovka.
            notifierB.ChangeValue("All of America is suddenly moving to Belarus.");

            // No one will be notified about this, because the value is the same.
            notifierA.ChangeValue("Snow fell all over America!");

            // This will not notify John Dow and Kid from Chizhovka again.
            notifierA.ChangeValue("Belarusians become fabulously rich..");

            Console.WriteLine();
        }
    }
}