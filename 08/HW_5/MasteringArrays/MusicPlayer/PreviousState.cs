using System;

namespace MusicPlayer
{
    public class PreviousState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***PreviousState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuStateGlobal();
        }
    }
}