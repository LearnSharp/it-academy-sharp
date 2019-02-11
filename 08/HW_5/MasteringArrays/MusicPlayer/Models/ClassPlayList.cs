﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlayer.Models
{
    public class PlayList
    {
        public PlayList()
        {
            Playlist = new List<Song>();

            //** set for example date
            SetExampleDate();
        }

        private static List<Song> Playlist { get; set; }

        private static void SetExampleDate()
        {
        #region

            //Album "Death Magnetic", 2008
            //AddSongPlaylist(new Song("That Was Just Your Life", "00:07:08", "Metallica"));
            //AddSongPlaylist(new Song("The End of the Line", "00:07:53", "Metallica"));
            //AddSongPlaylist(new Song("Broken, Beat & Scarred", "00:06:25", "Metallica"));
            //AddSongPlaylist(new Song("The Day That Never Comes", "00:07:56", "Metallica"));
            //AddSongPlaylist(new Song("All Nightmare Long", "00:07:57", "Metallica"));
            //AddSongPlaylist(new Song("Cyanide", "00:06:37", "Metallica"));
            //AddSongPlaylist(new Song("The Unforgiven III", "00:07:49", "Metallica"));
            //AddSongPlaylist(new Song("The Judas Kiss", "00:08:00", "Metallica"));
            //AddSongPlaylist(new Song("Suicide & Redemption", "00:09:56", "Metallica"));
            //AddSongPlaylist(new Song("My Apocalypse", "00:05:00", "Metallica"));

        #endregion

            AddOneSong(new Song("That Was Just Your Life", "00:00:08", "Metallica"));
            AddOneSong(new Song("The End of the Line", "00:00:03", "Metallica"));
            AddOneSong(new Song("Broken, Beat & Scarred", "00:00:05", "Metallica"));
            //AddOneSong(new Song("The Day That Never Comes", "00:00:06", "Metallica"));
            //AddOneSong(new Song("All Nightmare Long", "00:00:07", "Metallica"));
            //AddOneSong(new Song("Cyanide", "00:00:07", "Metallica"));
            //AddOneSong(new Song("The Unforgiven III", "00:00:09", "Metallica"));
            //AddOneSong(new Song("The Judas Kiss", "00:00:01", "Metallica"));
            //AddOneSong(new Song("Suicide & Redemption", "00:00:06", "Metallica"));
            //AddOneSong(new Song("My Apocalypse", "00:00:02", "Metallica"));
        }

        public Song GetSongByIndex(int index)
        {
            return Playlist.ElementAtOrDefault(index);
        }

        private Song GetSongByName(string name)
        {
            return Playlist.Single(x => x.NameSong == name);
        }

        public static void AddOneSong(Song song)
        {
            Playlist.Add(song);
        }

        public void AddAtIndexSong(int index, Song song)
        {
            Playlist.Insert(index, song);
        }

        public static int GetCount()
        {
            return Playlist.Count;
        }

        public static string GetAllTime()
        {
            var seconds = 0;
            foreach (var song in Playlist)
            {
                seconds += Convert.ToDateTime(song.TimeSong).Second;
            }

            return TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss");
        }

        private static void ShowPlaylist()
        {
            if (!Playlist.Any()) return;
            Console.WriteLine("Introduced Playlist:\n"
                                  .PadRight(20, '\u2500'));
            var num = 0;
            foreach (var it in Playlist) ShowRes(num, it);

            Console.WriteLine("\n".PadRight(20, '\u2500'));
        }

        private static void ShowRes(Song it)
        {
            Console.Write("{0},  {1} {2}\n",
                          it.NameSong, it.Author, it.TimeSong);
        }

        private static void ShowRes(int num, Song it)
        {
            Console.Write("{0}  {1}, {2} {3}\n",
                          ++num, it.NameSong, it.Author, it.TimeSong);
        }

        public void AllView()
        {
            Console.WriteLine("\n".PadRight(20, '\u2500'));
            ShowPlaylist();
        }

        private static void ShowItem(Song fnd)
        {
            if (fnd == null) return;
            Console.WriteLine("\nSearch completed:\t");
            ShowRes(fnd);
            Console.WriteLine();
        }

        public void FindByIndex()
        {
            Console.Write("Enter the song Index in the playlist: ");
            Program.SetEnterDecimal(Console.ReadLine(), out var num);
            var fnd = GetSongByIndex(Convert.ToInt16(num));
            if (fnd != null)
                ShowItem(fnd);
            else
                Console.WriteLine("Search returned no results.");
        }

        public void FindByName()
        {
            Console.Write("Enter the song title in the playlist: ");
            var fnd = GetSongByName(Console.ReadLine());
            if (fnd != null)
                ShowItem(fnd);
            else
                Console.WriteLine("Search returned no results.");
        }
    }
}