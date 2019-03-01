using System;
using System.Threading;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
    public class ForwardState : PlayStateBase, IState
    {
        IState IState.RunState()
        {
            HeaderState(StForward);

            var newThreadFind = new Thread(InterruptEndExecuteFindSong);
            newThreadFind.Start();

            SongHandler(Forward);

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