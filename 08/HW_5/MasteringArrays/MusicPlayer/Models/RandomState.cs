using System;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
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