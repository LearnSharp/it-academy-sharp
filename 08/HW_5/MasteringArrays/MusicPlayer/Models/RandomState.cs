using System;
using System.Threading;
using System.Threading.Tasks;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
    public class RandomState : PlayStateBase, IState
    {
        IState IState.RunState()
        {
            HeaderState(StRandom);

            var newThreadFind = new Thread(InterruptEndExecuteFindSong);
            newThreadFind.Start();

            SongHandler(Random);

            FooterState();
            return new MenuPlay();
        }


        private static void InterruptEndExecuteFindSong()
        {
            while (Console.KeyAvailable) Console.ReadKey(false);
            if (Console.ReadKey(false).Key == ConsoleKey.F) IsSeek = true;
        }
    }
}