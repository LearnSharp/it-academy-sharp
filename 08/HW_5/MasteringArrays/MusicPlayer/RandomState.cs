using System;

namespace MusicPlayer
{
    public class RandomState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***RandomState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuPlayList();
        }
    }
}