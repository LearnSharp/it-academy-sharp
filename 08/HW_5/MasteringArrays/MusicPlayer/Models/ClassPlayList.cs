using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlayer.Models
{
    public class ClassPlayList
    {
        public ClassPlayList()
        {
            var playList = new List<Song>();
            Playlist = playList;
        }

        private static List<Song> Playlist { get; set; }

        public ArrayList GetSongByIndex(int index)
        {
            var fnd = Playlist.ElementAtOrDefault(index);
            return fnd?.GetPlaylistView();
        }

        public ArrayList GetSongByName(string name)
        {
            foreach (var itm in Playlist)
                if (itm.GetPlaylistView().Contains(name))
                    return itm.GetPlaylistView();

            return null;
        }

        public void AddSongPlaylist(Song song)
        {
            Playlist.Add(song);
        }

        public int GetPlaylistCount()
        {
            return Playlist.Count;
        }


        private static void GetPlaylist()
        {
            if (!Playlist.Any()) return;
            Console.WriteLine("Introduced Playlist:\n"
                                  .PadRight(20, '\u2500'));
            var num = 0;
            foreach (var it in Playlist)
            {
                Console.Write("{0}  ", ++num);
                foreach (var i in it.GetPlaylistView())
                    Console.Write("{0} ", i);

                Console.WriteLine();
            }

            Console.WriteLine("\n".PadRight(20, '\u2500'));
        }

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMember.Local
        public void AllView()
        {
            Console.WriteLine("\n".PadRight(20, '\u2500'));
            GetPlaylist();
        }

        private static void GetItemView(IEnumerable fnd)
        {
            if (fnd == null) return;
            Console.WriteLine("\nSearch completed:\t");
            foreach (var item in fnd) Console.Write("{0} ", item);

            Console.WriteLine();
        }

        public void FindByIndex()
        {
            Console.Write("Enter the song Index in the playlist: ");
            Program.EnterDecimal(Console.ReadLine(), out var num);
            var fnd = GetSongByIndex(Convert.ToInt16(num));
            if (fnd != null) GetItemView(fnd);
            else Console.WriteLine("Search returned no results.");
        }

        public void FindByName()
        {
            Console.Write("Enter the song title in the playlist: ");
            var fnd = GetSongByName(Console.ReadLine());
            if (fnd != null) GetItemView(fnd);
            else Console.WriteLine("Search returned no results.");
        }
    }
}