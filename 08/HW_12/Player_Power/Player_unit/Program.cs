using System;
using System.Collections.Generic;

namespace Player_Power
{
    internal enum StdVoltage
    {
        V110 = 110,
        V127 = 127,
        V220 = 220,
        V380 = 380
    }

    public abstract class Power : IPlayer
    {
        private readonly IVoltage _voltage;

        internal Power(IVoltage voltage)
        {
            _voltage = voltage;
        }

        public int Voltage { get; set; }

        public void ShowVoltage()
        {
            Console.WriteLine("Voltage = {0}", _voltage.GetVoltage());
        }

        public abstract void Pause();
        public abstract void Start();
        public abstract void Stop();
    }

    public interface IVoltage
    {
        int GetVoltage();
    }

    internal class VoltageV110 : IVoltage
    {
        public int GetVoltage()
        {
            return (int) StdVoltage.V110;
        }
    }

    internal class VoltageV127 : IVoltage
    {
        public int GetVoltage()
        {
            return (int) StdVoltage.V127;
        }
    }

    internal class VoltageV220 : IVoltage
    {
        public int GetVoltage()
        {
            return (int) StdVoltage.V220;
        }
    }

    internal class VoltageV380 : IVoltage
    {
        public int GetVoltage()
        {
            return (int) StdVoltage.V380;
        }
    }

    public interface IPlayer
    {
        void Pause();
        void Start();
        void Stop();
    }

    public class Samsung : Power
    {
        private readonly IPlayer _player;

        public Samsung(IPlayer player, IVoltage voltage) :
            base(voltage) => _player = player;

        public override void Pause() => _player.Pause();
        public override void Start() => _player.Start();
        public override void Stop() => _player.Stop();
    }

    public class Panasonic : Power
    {
        private readonly IPlayer _player;

        public Panasonic(IPlayer player, IVoltage voltage) :
            base(voltage) => _player = player;

        public override void Pause() => _player.Pause();
        public override void Start() => _player.Start();
        public override void Stop() => _player.Stop();
    }

    public class Sony : Power
    {
        private readonly IPlayer _player;

        public Sony(IPlayer player, IVoltage voltage) :
            base(voltage) => _player = player;

        public override void Pause() => _player.Pause();
        public override void Start() => _player.Start();
        public override void Stop() => _player.Stop();
    }

    public class Player : IPlayer
    {
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
    }

    internal class Program
    {
        private delegate void Output<in T>(T obj);

        private static void ShowRes(Power producer)
        {
            producer.ShowVoltage();
            producer.Start();
            producer.Pause();
            producer.Stop();
        }

        private static void Main()
        {
            IPlayer player = new Player();
            var voltages = new List<IVoltage>
            {
                new VoltageV110(), new VoltageV127(),
                new VoltageV220(), new VoltageV380()
            };

            foreach (var voltage in voltages)
            {
                ShowRes(new Samsung(player, voltage));
                ShowRes(new Panasonic(player, voltage));
                ShowRes(new Sony(player, voltage));
            }

            Console.WriteLine();
        }
    }
}