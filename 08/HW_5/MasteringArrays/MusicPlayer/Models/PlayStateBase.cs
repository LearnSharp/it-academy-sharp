using System;
using System.Threading;

namespace MusicPlayer.Models
{
    public abstract class PlayStateBase
    {
        public void SongHandler(ClassPlayList PlaySonglist, int pos)
        {
            var idx = 0;
            SongHandler(PlaySonglist, pos, ref idx);
        }

        public void SongHandler(ClassPlayList PlaySonglist, int pos, ref int idx)
        {
            idx = pos;
            var tmpArray = PlaySonglist.GetSongByIndex(pos).ToArray();
            var songTitle = tmpArray.GetValue(0).ToString();
            var timeSong = tmpArray.GetValue(1).ToString();
            var authSong = tmpArray.GetValue(2).ToString();
            Console.WriteLine();
            ProgressPlay(songTitle + " " + authSong, timeSong);
            PlayStateHandler();
        }

        public void ProgressPlay(string nameSong,
                                 string timeSongString)
        {
            using (var progress = new ProgressBar())
            {
                Console.WriteLine("Playing composition:\n" + nameSong + " ");
                var timeSong = Convert.ToDateTime(timeSongString);
                var longSong = timeSong.Hour * 3600 + timeSong.Minute * 60 +
                               timeSong.Second;
                Console.WriteLine(" long Song = {0} sec.", longSong);
                var i = 0;
                while (i++ <= longSong)
                {
                    progress.Report((double) i / longSong);
                    Thread.Sleep(999);
                }

                progress.WriteLine(" .. Done.\n");
            }
        }

        public void PlayStateHandler()
        {
            //Console.WriteLine(" real PlayStateHandler..");
        }
    }
}