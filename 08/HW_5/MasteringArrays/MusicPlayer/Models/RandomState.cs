using System;
using System.Threading.Tasks;
using MusicPlayer.Interface;
using static MusicPlayer.Program;

namespace MusicPlayer.Models
{
    public class RandomState : PlayStateBase, IState
    {
        private delegate void HandlerEsc();

        IState IState.RunState()
        {
            HandlerEsc handlerEsc = HandLoopForward;
            HeaderState(CurrentPlaylist, StRandom);

            Task.Factory.StartNew(InterruptEndExecuteFindSong);
            handlerEsc();

            FooterState();
            //
            return new MenuPlay();
        }

        private void HandLoopForward()
        {
            do SongHandler(CurrentPlaylist, Random);
            while (!ControlEvent);
        }

        private static void InterruptEndExecuteFindSong()
        {
            var cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.F)
            {
                while (Console.KeyAvailable) Console.ReadKey(false);

                Console.Clear();
                Console.WriteLine("******** Method Find **********");

                ControlEvent = true;
            }
        }
    }
}