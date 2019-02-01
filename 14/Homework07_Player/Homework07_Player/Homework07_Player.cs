using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework07_Player
{
    class Homework07_Player
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Ram = 128;

            Console.WriteLine("Pproducer - {0}, Ram - {1} Gb.", player.Producer, player.Ram);
            Console.ReadKey();
        }
    }

    public class Player
    {
        private string _producer;
        private int _ram;

        public string Producer
        {
            get
            {
                if(_producer != null)
                {
                    return _producer;
                }
                else
                {
                    Console.WriteLine("Parametr 'Producer' is empty.");
                    return "";
                }
            }
        }

        public int Ram
        {
            set
            {
                if ((value == 16) || (value == 32) || (value == 64) || (value == 128) || (value == 256) || (value == 512))
                {
                    _ram = value;
                }
                else
                {
                    Console.WriteLine("Entered value is not valid.");
                }
            }

            get
            {
                if(_ram != 0)
                {
                    return _ram;
                }
                else
                {
                    Console.WriteLine("Parametr 'Ram' is 0.");
                    return 0;
                }
            }
        }
        public Player()
        {
            _producer = "Belarus";
            Console.WriteLine("Player has benn created. Producer - {0}", _producer);
        }
    }
}
