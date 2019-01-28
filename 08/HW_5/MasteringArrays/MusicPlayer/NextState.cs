using System;

namespace MusicPlayer
{
    public class NextState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***NextState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuStateGlobal();
        }
    }
}