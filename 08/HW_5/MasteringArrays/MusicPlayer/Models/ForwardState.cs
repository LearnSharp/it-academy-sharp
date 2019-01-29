using System;
using MusicPlayer.Interface;
using static MusicPlayer.Program;

namespace MusicPlayer.Models
{
    public class ForwardState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***Forward State: ***");

            for (var i = 0; i < PlaySonglist.GetPlaylistCount(); i++)
            {
                var tmpArray = PlaySonglist.GetSongByIndex(i).ToArray();
                var songTitle = tmpArray.GetValue(0).ToString();
                var timeSong = tmpArray.GetValue(1).ToString();
                Console.WriteLine();
                ProgressPlay(songTitle, timeSong);
            }

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
            return new MenuPlay();
        }
    }
}