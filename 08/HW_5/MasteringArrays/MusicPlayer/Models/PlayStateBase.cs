using System;
using System.Collections.Generic;
using System.Threading;

namespace MusicPlayer.Models
{
    public abstract class PlayStateBase
    {
        internal static bool ControlEvent { get; set; }
        internal const int Back = -1;
        internal const int Random = -2;

        internal const string StForward = "Forward";
        internal const string StBack = "Back";
        internal const string StRandom = "Random";

        private static readonly Random rng =
            new Random((int) DateTime.Now.Ticks & 0x0000FFFF);

        internal void HeaderState(PlayList PlaySonglist, string state)
        {
            Console.CursorVisible = false;
            Console.WriteLine("*** {0} State: ***", state);

            var cnt = PlaySonglist.GetCount();
            Console.WriteLine("\nTotal recorded tracks in the playlist - {0}", cnt);
            Console.WriteLine("\n**************************");
        }

        internal void FooterState()
        {
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.Clear();
        }

        internal void SongHandler(PlayList PlaySonglist)
        {
            var cnt = PlaySonglist.GetCount();
            for (var i = 0; i < cnt; i++)
            {
                SongHandler(PlaySonglist, i);
            }

            ControlEvent = true;
        }

        internal void SongHandler(PlayList PlaySonglist, int pos)
        {
            var idx = 0;
            var cnt = PlaySonglist.GetCount();

            switch (pos)
            {
                // play if pos==Back
                case Back:
                {
                    for (var i = cnt - 1; i >= 0; i--)
                    {
                        SongHandler(PlaySonglist, i);
                    }

                    ControlEvent = true;
                    break;
                }
                case Random:
                {
                    var tmpList = new int[cnt];
                    for (var i = 0; i < cnt; i++) tmpList[i] = i;
                    Shuffle(tmpList);

                    foreach (var ps in tmpList)
                    {
                        SongHandler(PlaySonglist, ps);
                    }

                    ControlEvent = true;
                    break;
                }
                default:
                    SongHandler(PlaySonglist, pos, ref idx);
                    break;
            }
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

        internal void SongHandler(PlayList PlaySonglist, int pos, ref int idx)
        {
            idx = pos;
            var cnt = PlaySonglist.GetCount();
            var tmpArray = PlaySonglist.GetSongByIndex(pos).ToArray();
            var songTitle = tmpArray.GetValue(0).ToString();
            var timeSong = tmpArray.GetValue(1).ToString();
            var authSong = tmpArray.GetValue(2).ToString();
            var input = idx + 1 + ". " + songTitle + " / " + authSong;
            ProgressPlay(cnt, input, timeSong);
        }

        internal void ProgressPlay(int cnt, string nameSong, string timeSongString)
        {
            using (var progress = new ProgressBar())
            {
                Console.WriteLine("\n {0} ", nameSong);
                var timeSong = Convert.ToDateTime(timeSongString);
                var longSong = timeSong.Hour * 3600 + timeSong.Minute * 60 +
                               timeSong.Second;
                Console.WriteLine(" Song duration ({0}) = {1} sec.", timeSongString,
                                  longSong);
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