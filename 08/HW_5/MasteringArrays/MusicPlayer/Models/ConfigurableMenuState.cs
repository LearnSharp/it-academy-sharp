using System;
using System.Collections.Generic;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
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
}