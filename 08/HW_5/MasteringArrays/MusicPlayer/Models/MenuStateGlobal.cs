using System.Collections.Generic;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
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
                {0, new MenuItem {Text = "Exit (Esc)"}}
            };


        /// <summary>
        /// Actions when selecting a menu item with a specific number
        /// </summary>
        /// <param name="selectedMenu">Specific number point menu</param>
        /// <returns></returns>
        protected override IState NextState(
            KeyValuePair<int, MenuItem> selectedMenu)
        {
            if (selectedMenu.Key == 0) return null;
            if (selectedMenu.Key == 1) return new PreviousState();
            if (selectedMenu.Key == 2) return new PlayState();
            if (selectedMenu.Key == 3) return new NextState();
            if (selectedMenu.Key == 4) return new MenuPlayList();

            return this;
        }
    }
}