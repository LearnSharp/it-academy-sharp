using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicPlayer.Interface;
using static MusicPlayer.Program;

namespace MusicPlayer.Models
{
    public class RandomState : PlayStateBase, IState
    {
        private static readonly Random rng =
            new Random((int) DateTime.Now.Ticks & 0x0000FFFF);

        private static bool ControlEvent { get; set; }
        private static int IndexOfSong { get; set; }
        private static List<int> CountOfSong { get; } = new List<int>();

        IState IState.RunState()
        {
            ControlEvent = false;
            Console.CursorVisible = false;
            Console.WriteLine("*** Random State: ***");
            var cnt = PlaySonglist.GetPlaylistCount();

            var tmpList = new int[cnt];
            for (var i = 0; i < cnt; i++) tmpList[i] = i;
            Shuffle(tmpList);

            foreach (var id in tmpList)
                CountOfSong.Add(id);

            Task.Factory.StartNew(InterruptEndExecuteFindSong);

            foreach (var pos in tmpList)
                if (!ControlEvent)
                {
                    IndexOfSong = pos;
                    SongHandler(PlaySonglist, pos);
                }

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.CursorVisible = true;
            Console.ReadKey(true);
            return new MenuPlay();
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


        private static void Shuffle(IList<int> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}