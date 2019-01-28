using System;
using System.Threading;
using static MusicPlayer.Program;

namespace MusicPlayer
{
    public class PlayState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***PlayState: ***\n");

            var tmpArray = PlaySonglist.GetSongByIndex(0).ToArray();
            var songTitle = tmpArray.GetValue(0).ToString();
            var timeSong = tmpArray.GetValue(1).ToString();
            ProgressPlay(songTitle, timeSong);

            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();
            return new MenuStateGlobal();
        }

        private static void ProgressPlay(string nameSong, string timeSongString)
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
                    Thread.Sleep(1000);
                }

                progress.WriteLine(" .. Done.");
            }
        }
    }
}