using System;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
    public class AddState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***Add State: ***\n");

            ConsoleKeyInfo inp;
            do
            {
                var song = new Song();
                song.RecordSong();
                Program.CurrentPlaylist.AddOneSong(song);

                Console.WriteLine("\nContinue entering?\nPress any key " +
                                  "for continue or Esc for exit.\n");
                inp = Console.ReadKey(true);
            } while (inp.Key != ConsoleKey.Escape);

            Console.Clear();
            return new MenuPlayList();
        }
    }
}