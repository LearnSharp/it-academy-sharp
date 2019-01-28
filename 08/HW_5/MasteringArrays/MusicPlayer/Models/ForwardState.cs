using System;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
    public class ForwardState : IState
    {
        IState IState.RunState()
        {
            Console.WriteLine("***ForwardState: ***");

            Console.ReadLine();
            Console.Clear();
            return new MenuPlayList();
        }
    }
}