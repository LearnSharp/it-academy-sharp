using System;
using System.Collections.Generic;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
    public abstract class MenuState : IState
    {
        protected abstract Dictionary<int, MenuItem> Menus { get; }

        public virtual IState RunState()
        {
            var option = ReadOption();
            Console.Clear();
            return NextState(option);
        }

        protected virtual void ShowMenu()
        {
            Console.WriteLine("You have options:");
            foreach (var m in Menus) Console.WriteLine($"{m.Key} - {m.Value.Text}");
        }

        protected virtual KeyValuePair<int, MenuItem> ReadOption()
        {
            Console.WriteLine("Please, select option:");
            ShowMenu();

            var UserInput = Console.ReadKey(true);

            if (UserInput.Key == ConsoleKey.Escape ||
                char.IsDigit(UserInput.KeyChar))
            {
                var answerId = UserInput.Key == ConsoleKey.Escape
                    ? 0
                    : int.Parse(UserInput.KeyChar.ToString());

                if (Menus.ContainsKey(answerId))
                    return new KeyValuePair<int, MenuItem>
                        (answerId, Menus[answerId]);
            }

            Console.Clear();
            Console.WriteLine("Selected item not exists, repeat your choice.");
            return ReadOption();
        }

        protected abstract IState NextState(
            KeyValuePair<int, MenuItem> selectedMenu);
    }
}