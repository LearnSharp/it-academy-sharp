using System;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
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