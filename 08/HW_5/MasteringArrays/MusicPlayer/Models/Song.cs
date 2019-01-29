using System;
using System.Collections;

namespace MusicPlayer.Models
{
        public class Song
        {
            public string NameSong { get; set; }
            public string TimeSong { get; set; }
            public string Author { get; set; }

            public void RecordSong()
            {
                Console.WriteLine("Enter Song\n" +
                                  "".PadRight(40, '\u2500'));

                Console.Write("Song title: ");
                NameSong = Console.ReadLine();

                Console.WriteLine("Playing time (hh:mm:ss):");
                Program.EnterTime(out var timeSongString);
                TimeSong = timeSongString;

                Console.Write("\nThe name of the author: ");
                Author = Console.ReadLine();
            }

            public ArrayList GetPlaylistView()
            {
                return new ArrayList
                    {NameSong, TimeSong, Author};
            }
        }
    
}