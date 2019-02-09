using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Power
{
    internal enum StdVoltage
    {
        V110 = 110,
        V127 = 127,
        V220 = 220,
        V380 = 380
    }

    public interface IVoltage
    {
        int Voltage { get; set; }
        void ShowVoltage();
    }

    public class Power : IVoltage
    {
        private readonly IVoltage _voltage;

        public Power(IVoltage voltage)
        {
            _voltage = voltage;
        }

        public int Voltage { get; set; }

        public void ShowVoltage()
        {
            Console.WriteLine("Voltage = {0}", Voltage);
        }
    }


    public interface IPlayer
    {
        void Pause();
        void Start();
        void Stop();
    }

    public class Samsung : IPlayer, IVoltage
    {
        public IPlayer Player { get; set; }
        private readonly IVoltage _voltage;

        public int Voltage
        {
            get => _voltage.Voltage;
            set => _voltage.Voltage = value;
        }

        public Samsung(IPlayer player, IVoltage voltage)
        {
            _voltage = voltage;
            Player = player;
        }

        public void Pause()
        {
            Console.WriteLine("Pause.");
        }

        public void Start()
        {
            Console.WriteLine("Play.");
        }

        public void Stop()
        {
            Console.WriteLine("Stop.");
        }

        public void ShowVoltage()
        {
            Console.WriteLine("Voltage = {0}", _voltage);
        }
    }


    internal class Program
    {
        private static void Main()
        {
        }
    }
}