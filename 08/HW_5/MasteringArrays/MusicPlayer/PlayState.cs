using System;

namespace MusicPlayer
{
    public class PlayState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***PlayState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuStateGlobal();
        }
    }
}