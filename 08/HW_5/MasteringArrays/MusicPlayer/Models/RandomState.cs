using System;
using System.Collections;
using System.Collections.Generic;
using MusicPlayer.Interface;
using static MusicPlayer.Program;

namespace MusicPlayer.Models
{
    public class RandomState : IState
    {
        private static readonly Random rng =
            new Random((int) DateTime.Now.Ticks & 0x0000FFFF);

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


        IState IState.RunState()
        {
            Console.WriteLine("***Random State: ***");

            var cnt = PlaySonglist.GetPlaylistCount();

            var tmpList = new int[cnt];
            for (var i = 0; i < cnt; i++) tmpList[i] = i;
            Shuffle(tmpList);

            foreach (var pos in tmpList)
            {
                var tmpArray = PlaySonglist.GetSongByIndex(pos).ToArray();
                var songTitle = tmpArray.GetValue(0).ToString();
                var timeSong = tmpArray.GetValue(1).ToString();
                var authSong = tmpArray.GetValue(2).ToString();
                Console.WriteLine();
                ProgressPlay(songTitle + authSong, timeSong);
            }

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
            return new MenuPlay();
        }
    }
}