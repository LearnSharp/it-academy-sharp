using MusicPlayer.Interface;
using MusicPlayer.Models;

namespace MusicPlayer
{
    public partial class Program
    {
        public static PlayList CurrentPlaylist { get; set; } =
            new PlayList();

        private static void LoadContent()
        {
            IState startState = new MenuStateGlobal();
            while (startState != null) startState = startState.RunState();
        }

        private static void Main()
        {
            LoadContent();
        }
    }
}