using System;
using System.Threading;

namespace MusicPlayer
{
    public class PlayState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***PlayState: ***\n");
            ProgressPlay("Kino", "00:00:20");




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
                var longSong = timeSong.Hour * 3600 + timeSong.Minute * 60 + timeSong.Second;
                Console.WriteLine(" long Song = {0} sec.", longSong);
                var i = 0;
                while (i++ <= longSong)
                {
                    progress.Report((double)i / longSong);
                    Thread.Sleep(1000);
                }
                progress.WriteLine(" .. Done.");
            }
        }
    }
}