using System;

namespace MusicPlayer
{
    public class AddState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***AddState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuPlayList();
        }
    }
}