using System.Collections.Generic;

namespace MusicPlayer
{
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
}