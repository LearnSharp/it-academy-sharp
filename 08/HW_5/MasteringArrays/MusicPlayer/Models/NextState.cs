using System;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
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