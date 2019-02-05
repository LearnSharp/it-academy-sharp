using System;
using System.Collections.Generic;
//using System.Threading.Tasks;
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

            handlerEsc();

            FooterState();
            //Task.Factory.StartNew(InterruptEndExecuteFindSong);
            return new MenuPlay();
        }

        private void HandLoopForward()
        {
            do SongHandler(CurrentPlaylist, Random);
            while (!ControlEvent);
        }

        private static void InterruptEndExecuteFindSong()
        {
            //var cki = Console.ReadKey(true);
            //if (cki.Key== ConsoleKey.F)
            //{
            //    while (Console.KeyAvailable) Console.ReadKey(false);

            //    Console.Clear();
            //    Console.WriteLine("******** Method Find **********");

            //    var tmpArray = PlaySonglist.GetSongByIndex(0).ToArray();
            //    var songTitle = tmpArray.GetValue(0).ToString();
            //    var timeSong = tmpArray.GetValue(1).ToString();
            //    var authSong = tmpArray.GetValue(2).ToString();
            //    var tmpSong = new Song(songTitle, timeSong, authSong);
            //    PlaySonglist.AddAtIndexSongPlaylist(IndexOfSong, tmpSong);
            //    ControlEvent = true;
            //    foreach (var pos in CountOfSong)
            //        SongHandler(PlaySonglist, pos);
            //}
            //Console.Clear();
            Console.WriteLine("\n**************************");
        }
    }
}