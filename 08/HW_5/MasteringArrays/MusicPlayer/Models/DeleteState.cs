using System;
using MusicPlayer.Interface;

namespace MusicPlayer.Models
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