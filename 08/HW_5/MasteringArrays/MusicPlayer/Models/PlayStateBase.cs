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

        protected static bool IsSeek { get; set; }

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
            while (Console.KeyAvailable) Console.ReadKey(false);
            Console.ReadKey();
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

        public static void SongHandler()
        {
            var cnt = PlayList.GetCount();
            for (var i = 0; i < cnt; i++) SongHandler(i);
        }

        public static void SongHandler(int direction)
        {
            var idx = direction;
            var cnt = PlayList.GetCount();
            if (direction == Back)
            {
                for (var i = cnt - 1; i >= 0; i--) SongHandler(i);
            }
            else if (direction == Random)
            {
                var tmpList = new int[cnt];
                for (var i = 0; i < cnt; i++) tmpList[i] = i;
                Shuffle(tmpList);
                foreach (var ps in tmpList)
                {
                    if (idx == 0) break;
                    SongHandler(ps, ref idx);
                }
            }
            else
            {
                SongHandler(direction, ref idx);
            }
        }

        private static void SongHandler(int p, ref int direction)
        {
            if (IsSeek)
            {
                while (Console.KeyAvailable) Console.ReadKey(false);
                Console.Clear();
                PlayList.AddOneSong(PlayList.FindByIndex());
                IsSeek = false;
                SongHandler(direction);
                direction = 0;
            }
            else
                ProgressPlay(PlayList.GetSongByIndex(p), p);
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
                                  idx + 1, song?.TimeSong, longSong);
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