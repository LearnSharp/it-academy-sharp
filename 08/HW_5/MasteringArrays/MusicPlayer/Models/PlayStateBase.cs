using System;
using System.Collections.Generic;
using System.Threading;

namespace MusicPlayer.Models
{
    public abstract class PlayStateBase
    {
        internal const int Back = -1;
        internal const int Random = -2;

        internal const string StForward = "Forward";
        internal const string StBack = "Back";
        internal const string StRandom = "Random";

        private static readonly Random rng =
            new Random((int) DateTime.Now.Ticks & 0x0000FFFF);

        protected static bool ControlEvent { get; set; }

        protected static void HeaderState(string state)
        {
            Console.CursorVisible = false;
            Console.WriteLine("*** {0} State: ***", state);
            Console.WriteLine("\nTotal recorded tracks in the " +
                              "playlist - {0}", PlayList.GetCount());
            Console.WriteLine("Total recording time in the " +
                              "playlist - {0}", PlayList.GetAllTime());
            Console.WriteLine("\n**************************");
        }

        protected static void FooterState()
        {
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.Clear();
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

        public static void SongHandler(PlayList PlaySonglist)
        {
            var cnt = PlayList.GetCount();
            for (var i = 0; i < cnt; i++) SongHandler(PlaySonglist, i);

            ControlEvent = true;
        }

        public static void SongHandler(PlayList PlaySonglist, int direction)
        {
            var idx = 0;
            var cnt = PlayList.GetCount();
            switch (direction)
            {
                //plays backward if selected direction==Back
                case Back:
                {
                    for (var i = cnt - 1; i >= 0; i--) SongHandler(PlaySonglist, i);

                    ControlEvent = true;
                    break;
                }
                //plays random if selected direction==Random
                case Random:
                {
                    var tmpList = new int[cnt];
                    for (var i = 0; i < cnt; i++) tmpList[i] = i;
                    Shuffle(tmpList);

                    foreach (var ps in tmpList) SongHandler(PlaySonglist, ps, ref idx);

                    ControlEvent = true;
                    break;
                }
                default:
                    SongHandler(PlaySonglist, direction, ref idx);
                    break;
            }
        }

        private static void SongHandler(PlayList PlaySonglist, int pos, ref int idx)
        {
            idx = pos;
            ProgressPlay(PlaySonglist.GetSongByIndex(pos),idx);
        }

        private static void ProgressPlay(Song song, int idx)
        {
            using (var progress = new ProgressBar())
            {
                song?.ShowRes(song);
                var timeSong = Convert.ToDateTime(song?.TimeSong);
                var longSong = timeSong.Hour * 3600 +
                               timeSong.Minute * 60 +
                               timeSong.Second;
                Console.WriteLine("{0}. Song duration ({1}) = {2} sec.",
                                  idx+1, song?.TimeSong, longSong);
                var i = 0;
                while (i++ <= longSong)
                {
                    progress.Report((double) i / longSong);
                    Thread.Sleep(999);
                }

                progress.WriteLine(" .. Done.\n");
            }
        }
    }
}