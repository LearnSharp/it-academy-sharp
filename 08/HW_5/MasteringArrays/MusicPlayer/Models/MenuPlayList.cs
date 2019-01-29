using System.Collections.Generic;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
    public class MenuPlayList : MenuState
    {
        /// <summary>
        ///     Creating list of menu
        /// </summary>
        protected override Dictionary<int, MenuItem> Menus { get; } =
            new Dictionary<int, MenuItem>
            {
                {1, new MenuItem {Text = "Add"}},
                {2, new MenuItem {Text = "Delete"}},
                {0, new MenuItem {Text = "Return to main menu (Esc)"}}
            };

        /// <summary>
        ///     Actions when selecting a menu item with a specific number
        /// </summary>
        /// <param name="selectedMenu">Specific number point menu</param>
        /// <returns></returns>
        protected override IState NextState(
            KeyValuePair<int, MenuItem> selectedMenu)
        {
            if (selectedMenu.Key == 0) return new MenuStateGlobal();
            if (selectedMenu.Key == 1) return new AddState();
            if (selectedMenu.Key == 2) return new DeleteState();

            return new MenuStateGlobal();
        }
    }
}