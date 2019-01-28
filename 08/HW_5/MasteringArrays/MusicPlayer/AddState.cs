using System;
using static MusicPlayer.Program;

namespace MusicPlayer
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
                PlaySonglist.AddPlaylist(song);

                Console.WriteLine("\nContinue entering?\nPress any key " +
                                  "for continue or Esc for exit.\n");
                inp = Console.ReadKey(true);
            } while (inp.Key != ConsoleKey.Escape);

            Console.Clear();
            return new MenuPlayList();
        }
    }
}