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
            Console.Clear();
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
                Console.Clear();
                Console.WriteLine("Selected item not exists.");
                return ReadOption();
            }

            Console.Clear();
            Console.WriteLine("Selected item not a number.");
            return ReadOption();
        }

        protected abstract IState NextState(
            KeyValuePair<int, MenuItem> selectedMenu);
    }


    public class MenuStateGlobal : MenuState
    {
        /// <summary>
        /// Creating list of menu
        /// </summary>
        protected override Dictionary<int, MenuItem> Menus { get; } =
            new Dictionary<int, MenuItem>
            {
                {1, new MenuItem {Text = "Previous"}},
                {2, new MenuItem {Text = "Play"}},
                {3, new MenuItem {Text = "Next"}},
                {4, new MenuItem {Text = "Play List"}},
                {5, new MenuItem {Text = "Exit"}}
            };


        /// <summary>
        /// Actions when selecting a menu item with a specific number
        /// </summary>
        /// <param name="selectedMenu">Specific number point menu</param>
        /// <returns></returns>
        protected override IState NextState(
            KeyValuePair<int, MenuItem> selectedMenu)
        {
            if (selectedMenu.Key == 5) return null;
            if (selectedMenu.Key == 1) return new PreviousState();
            if (selectedMenu.Key == 2) return new PlayState();
            if (selectedMenu.Key == 3) return new NextState();
            if (selectedMenu.Key == 4) return new MenuPlayList();

            return this;
        }
    }

    public class PreviousState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***PreviousState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuStateGlobal();
        }
    }

    public class PlayState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***PlayState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuStateGlobal();
        }
    }

    public class NextState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***NextState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuStateGlobal();
        }
    }


    public class MenuPlayList : MenuState
    {
        /// <summary>
        /// Creating list of menu
        /// </summary>
        protected override Dictionary<int, MenuItem> Menus { get; } =
            new Dictionary<int, MenuItem>
            {
                {1, new MenuItem {Text = "Add"}},
                {2, new MenuItem {Text = "Delete"}},
                {3, new MenuItem {Text = "Play list forward"}},
                {4, new MenuItem {Text = "Play list back"}},
                {5, new MenuItem {Text = "Play list random"}},
                {6, new MenuItem {Text = "Exit"}}
            };


        /// <summary>
        /// Actions when selecting a menu item with a specific number
        /// </summary>
        /// <param name="selectedMenu">Specific number point menu</param>
        /// <returns></returns>
        protected override IState NextState(
            KeyValuePair<int, MenuItem> selectedMenu)
        {
            if (selectedMenu.Key == 6) return new MenuStateGlobal();
            if (selectedMenu.Key == 1) return new AddState();
            if (selectedMenu.Key == 2) return new DeleteState();
            if (selectedMenu.Key == 3) return new ForwardState();
            if (selectedMenu.Key == 4) return new BackState();
            if (selectedMenu.Key == 5) return new RandomState();

            return new MenuStateGlobal();
        }
    }

    public class AddState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***AddState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuPlayList();
        }
    }

    public class DeleteState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***DeleteState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuPlayList();
        }
    }

    public class ForwardState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***ForwardState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuPlayList();
        }
    }

    public class BackState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***BackState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuPlayList();
        }
    }

    public class RandomState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***RandomState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuPlayList();
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
        //private static void Test()
        //{
        //    var menuState = new ConfigurableMenuState();
        //    menuState.AddMenuItem(1, new MenuItem {Text = "Option 1"},
        //                          () => new AuthState());
        //    menuState.AddMenuItem(2, new MenuItem {Text = "Exit"},
        //                          () => null);

        //    IState startState = menuState;
        //    while (startState != null) startState = startState.RunState();
        //}

        //private static void Test1()
        //{
        //    IState startState = new AuthState();
        //    while (startState != null) startState = startState.RunState();
        //}

        private static void Test()
        {
            IState startState = new MenuStateGlobal();
            while (startState != null) startState = startState.RunState();
        }

        private static void Main()
        {
            Test();
        }
    }
}