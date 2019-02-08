using System;
using System.Collections.Generic;

namespace Vehicles
{
    internal class Program
    {
        private static void Main()
        {
            var vehicles = new List<Vehicle>
            {
                new Plane(20, 45, 650, 1500000, 2015, 10000, 200),
                new Ship(25, 38, 28, 2000000, 1990, "Amsterdam", 1200),
                new Car(23, 40, 5, 15000, 2000)
            };

            foreach (var vehicle in vehicles) vehicle.GetInfo();
        }

        public class Vehicle
        {
            public Vehicle(int longitude, int latitude, int speed, int cost,
                           int yearOfIssue)
            {
                Longitude = longitude;
                Latitude = latitude;
                Speed = speed;
                Cost = cost;
                YearOfIssue = yearOfIssue;
            }

            public int Longitude { get; set; }
            public int Latitude { get; set; }

            public int Speed { get; }
            public int Cost { get; }
            public int YearOfIssue { get; }

            public virtual void GetInfo()
            {
                Console.WriteLine("Coordinates vehicle: Longitude {0},  Latitude {1}\n" +
                                  "Speed = {2}, Cost ${3},  Year Of Issue - {4}",
                                  Longitude, Latitude, Speed, Cost, YearOfIssue);
            }
        }

        public class Plane : Vehicle
        {
            public Plane(int longitude, int latitude, int speed, int cost, int yearOfIssue,
                         int height, int numberOfPassengers)
                : base(longitude, latitude, speed, cost, yearOfIssue)
            {
                Height = height;
                NumberOfPassengers = numberOfPassengers;
            }

            public int Height { get; set; }
            public int NumberOfPassengers { get; set; }

            public override void GetInfo()
            {
                base.GetInfo();
                Console.WriteLine("Height = {0}, Number Of Passengers = {1}\n", Height,
                                  NumberOfPassengers);
            }
        }

        public class Car : Vehicle
        {
            public Car(int longitude, int latitude, int speed, int cost, int yearOfIssue) :
                base(longitude, latitude, speed, cost, yearOfIssue)
            {
            }
        }

        public class Ship : Vehicle
        {
            public Ship(int longitude, int latitude, int speed, int cost, int yearOfIssue,
                        string port, int numberOfPassengers) :
                base(longitude, latitude, speed, cost, yearOfIssue)
            {
                Port = port;
                NumberOfPassengers = numberOfPassengers;
            }

            public string Port { get; set; }
            public int NumberOfPassengers { get; set; }

            public override void GetInfo()
            {
                base.GetInfo();
                Console.WriteLine("Port = {0}, Number Of Passengers = {1}\n", Port,
                                  NumberOfPassengers);
            }
        }
    }
}