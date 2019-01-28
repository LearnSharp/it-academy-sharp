using System;

namespace MusicPlayer
{
    public class BackState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***BackState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuPlayList();
        }
    }
}