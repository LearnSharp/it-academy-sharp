using System;
using MusicPlayer.Interface;
using static MusicPlayer.Program;

namespace MusicPlayer.Models
{
    public class BackState : PlayStateBase, IState
    {
        private static bool ControlEvent { get; set; }
        IState IState.RunState()
        {
            Console.CursorVisible = false;
            Console.WriteLine("*** Back State: ***");

            for (var i = PlaySonglist.GetPlaylistCount() - 1; i >= 0; i--)
            {
                while (!ControlEvent)
                {
                    var tmpArray = PlaySonglist.GetSongByIndex(i).ToArray();
                    var songTitle = tmpArray.GetValue(0).ToString();
                    var timeSong = tmpArray.GetValue(1).ToString();
                    var authSong = tmpArray.GetValue(2).ToString();
                    Console.WriteLine();
                    ProgressPlay(songTitle + " " + authSong, timeSong);
                }
            }

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.CursorVisible = true;
            Console.ReadLine();
            Console.Clear();
            return new MenuPlay();
        }
    }
}