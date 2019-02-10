using System;

namespace Player_Interfaces
{
    public interface IPlayable
    {
        void Start();
        void Pause();
        void Stop();
    }

    public interface IRecodable
    {
        void Record();
        void Pause();
        void Stop();
    }

    public class Play : IPlayable
    {
        public void Start() => Console.WriteLine("Play...");

        public void Pause() => Console.WriteLine("Play Pause.");

        public void Stop() => Console.WriteLine("Play Stop.");
    }

    public class Recording : IRecodable
    {
        public void Record() => Console.WriteLine("Record...");

        public void Pause() => Console.WriteLine("Record Pause.");

        public void Stop() => Console.WriteLine("Record Stop.");
    }

    public class Player : IPlayable, IRecodable
    {
        public Player(IPlayable play, IRecodable record)
        {
            Play = play;
            Record = record;
        }

        public IPlayable Play { get; set; }
        public IRecodable Record { get; set; }

        void IPlayable.Start() => Play.Start();
        void IPlayable.Pause() => Play.Pause();
        void IPlayable.Stop() => Play.Stop();

        void IRecodable.Record() => Record.Record();
        void IRecodable.Pause() => Record.Pause();
        void IRecodable.Stop() => Record.Stop();
    }
    
    internal class Program
    {
        private delegate void Playing(Player obj);

        private static void ShowPlay(Player player)
        {
            player.Play.Start();
            player.Play.Pause();
            player.Play.Stop();
        }

        private static void ShowRecord(Player player)
        {
            player.Record.Record();
            player.Record.Pause();
            player.Record.Stop();
        }

        private static void Main()
        {
            IPlayable play = new Play();
            IRecodable recodable = new Recording();

            Playing playing = ShowPlay;
            playing += ShowRecord;
            playing += ShowPlay;

            playing(new Player(play, recodable));
        }
    }
}