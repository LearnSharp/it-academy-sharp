using System;

namespace MusicPlayer
{
    public class DeleteState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***DeleteState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuPlayList();
        }
    }
}