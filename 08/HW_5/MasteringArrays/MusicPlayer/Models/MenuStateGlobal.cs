using System.Collections.Generic;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
    public class MenuStateGlobal : MenuState
    {
        /// <summary>
        ///     Creating list of menu
        /// </summary>
        protected override Dictionary<int, MenuItem> Menus { get; } =
            new Dictionary<int, MenuItem>
            {
                {1, new MenuItem {Text = "Playlist"}},
                {2, new MenuItem {Text = "Player"}},
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
            if (selectedMenu.Key == 0) return null;
            if (selectedMenu.Key == 1) return new MenuPlayList();
            if (selectedMenu.Key == 2) return new MenuPlay();

            return this;
        }
    }
}