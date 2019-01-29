using System;
using System.Collections.Generic;
using System.Threading;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
    public class MenuPlay : MenuState
    {
        /// <summary>
        ///     Creating list of menu
        /// </summary>
        protected override Dictionary<int, MenuItem> Menus { get; } =
            new Dictionary<int, MenuItem>
            {
                {1, new MenuItem {Text = "Play forward"}},
                {2, new MenuItem {Text = "Play back"}},
                {3, new MenuItem {Text = "Play random"}},
                {0, new MenuItem {Text = "Exit (Esc)"}}
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
            if (selectedMenu.Key == 1) return new ForwardState();
            if (selectedMenu.Key == 2) return new BackState();
            if (selectedMenu.Key == 3) return new RandomState();

            return new MenuStateGlobal();
        }
    }
}
