using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework03_2
{
    class Homework03_2
    {
        //Переход дороги по регулируемому пешеходному переходу

        static void Main(string[] args)
        {
            string color;
            string carStoped;
            string greenLightBlink;

            Console.WriteLine("Hello! We are near crosswalk.");
            Console.WriteLine("What color is lit at the traffic lights? Enter 'red' or 'green'.");
            color = Convert.ToString(Console.ReadLine());

            while(IsRedLight(color))
            {
                Console.WriteLine("Stop and wait!");
                Console.WriteLine("What color is lit at the traffic lights? Enter 'red' or 'green'.");

                color = Convert.ToString(Console.ReadLine());
            }

            Console.WriteLine("Check that all cars stoped! All cars stoped 'yes' or 'no' ?");
            carStoped = Convert.ToString(Console.ReadLine());

            while(!IsCarStoped(carStoped))
            {
                Console.WriteLine("Stop and wait!");
                Console.WriteLine("All cars stoped 'yes' or 'no' ?");

                carStoped = Convert.ToString(Console.ReadLine());
            }

            Console.WriteLine("Let's go! Traffic light - green, cars  stopped.");
            Console.WriteLine("Began to go.");
            Console.WriteLine("Is green light blinking? 'yes' or 'no'");

            greenLightBlink = Convert.ToString(Console.ReadLine());

            while(!greenLightBlink.Equals("yes") && !greenLightBlink.Equals("no"))
            {
                Console.WriteLine("Enter only 'red' or 'green'!");
                Console.WriteLine("Is green light blinking? 'yes' or 'no'");

                greenLightBlink = Convert.ToString(Console.ReadLine());
            }

            if(IsGreenLightBlink(greenLightBlink))
            {
                Console.WriteLine("Ruuuun! Run to other side of road.");
            }
            else
            {
                Console.WriteLine("You are going to other side of road.");
            }

            Console.WriteLine("Congratulation! You have crossed the road.");
            Console.WriteLine("Press any key for exit.");
            Console.ReadKey();
        }

        private static bool IsRedLight(string color)
        {
            switch(color)
            {
                case "red":
                    {
                        return true;
                    }
                case "green":
                    {
                        return false;
                    }
                default:
                    {
                        Console.WriteLine("Enter only 'red' or 'green'!");
                        return true;                      
                    }
            }
        }

        private static bool IsCarStoped(string carStoped)
        {
            switch (carStoped)
            {
                case "yes":
                    {
                        return true;
                    }
                case "no":
                    {
                        return false;
                    }
                default:
                    {
                        Console.WriteLine("Enter only 'yes' or 'no'!");
                        return false;
                    }
            }
        }

        private static bool IsGreenLightBlink(string greenLightBlink)
        {
            switch (greenLightBlink)
            {
                case "yes":
                    {
                        return true;
                    }
                case "no":
                    {
                        return false;
                    }
                default:
                    {
                        Console.WriteLine("Enter only 'yes' or 'no'!");
                        return false;
                    }
            }
        }
    }
}
