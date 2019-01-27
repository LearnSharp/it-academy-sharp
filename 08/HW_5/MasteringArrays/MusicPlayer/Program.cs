using System;
using System.Collections.Generic;

namespace MusicPlayer
{
    public interface IState
    {
        IState RunState();
    }

    public class MenuItem
    {
        public string Text { get; set; }
    }

    public abstract class MenuState : IState
    {
        protected abstract Dictionary<int, MenuItem> Menus { get; }

        public virtual IState RunState()
        {
            var option = ReadOption();
            return NextState(option);
        }

        protected virtual void ShowMenu()
        {
            Console.WriteLine("You have options:");
            foreach (var m in Menus)
                Console.WriteLine($"{m.Key} - {m.Value.Text}");
        }

        protected virtual KeyValuePair<int, MenuItem> ReadOption()
        {
            Console.WriteLine("Please, select option:");
            ShowMenu();

            var str = Console.ReadLine();

            if (int.TryParse(str, out var answerId))
            {
                if (Menus.ContainsKey(answerId))
                    return new KeyValuePair<int, MenuItem>(answerId,
                                                           Menus[answerId]);
                Console.WriteLine("Selected item not exists.");
                return ReadOption();
            }

            Console.WriteLine("Selected item not a number.");
            return ReadOption();
        }

        protected abstract IState NextState(
            KeyValuePair<int, MenuItem> selectedMenu);
    }

    public class MenuState1 : MenuState
    {
        protected override Dictionary<int, MenuItem> Menus { get; } =
            new Dictionary<int, MenuItem>
            {
                {1, new MenuItem {Text = "Menu 1"}},
                {2, new MenuItem {Text = "Menu 2"}},
                {3, new MenuItem {Text = "Menu 3"}},
                {4, new MenuItem {Text = "Exit"}}
            };

        protected override IState NextState(
            KeyValuePair<int, MenuItem> selectedMenu)
        {
            if (selectedMenu.Key == 4) return null;
            if (selectedMenu.Key == 1) return new AuthState();
            return this;
        }
    }

    public class AuthState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("Login: ");
            var login = Console.ReadLine();
            Console.WriteLine("Password: ");
            // ReSharper disable once UnusedVariable
            var password = Console.ReadLine();

            Console.WriteLine($"Hello, {login}");

            return new MenuState1();
        }
    }

    public class ConfigurableMenuState : MenuState
    {
        private readonly Dictionary<int, MenuItem> _menus =
            new Dictionary<int, MenuItem>();

        private readonly Dictionary<int, Func<IState>> _transitions =
            new Dictionary<int, Func<IState>>();

        protected override Dictionary<int, MenuItem> Menus => _menus;

        protected override IState NextState(
            KeyValuePair<int, MenuItem> selectedMenu)
        {
            return _transitions[selectedMenu.Key]();
        }

        public void AddMenuItem(int id, MenuItem menu, Func<IState> nextState)
        {
            _menus.Add(id, menu);
            _transitions.Add(id, nextState);
        }
    }


    internal class Program
    {
        private static void Test()
        {
            var menuState = new ConfigurableMenuState();
            menuState.AddMenuItem(1, new MenuItem {Text = "Option 1"},
                                  () => menuState);
            menuState.AddMenuItem(2, new MenuItem {Text = "Exit"},
                                  () => null);

            IState startState = menuState;
            while (startState != null) startState = startState.RunState();
        }

        private static void Main()
        {
            Test();
        }
    }
}