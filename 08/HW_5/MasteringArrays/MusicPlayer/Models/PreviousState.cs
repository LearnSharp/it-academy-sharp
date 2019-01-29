using System;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
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