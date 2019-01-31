using System;
using System.Collections;

namespace MusicPlayer.Models
{
    public class Song
    {
        public Song(string nameSong, string timeSong, string author)
        {
            NameSong = nameSong;
            TimeSong = timeSong;
            Author = author;
        }

        public Song()
        {
        }

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
            Program.SetEnterTimePlay(out var timeSongString);
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