using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Recap.Assignment_3
{
    public class Assignment_3
    {
        public static void Execute()
        {
            var city1 = new City() { Id = 1, Name = "City1", Population = 60 };
            var city2 = new City() { Id = 2, Name = "City2", Population = 250 };
            var city3 = new City() { Id = 3, Name = "City3", Population = 0 };
            var city4 = new City() { Id = 4, Name = "City4" };

            GetMyCityName(city1);
            GetMyCityName(city2);
            GetMyCityName(city3);
            GetMyCityName(city4);

            Console.WriteLine("\n==========================================");
            Console.WriteLine(Environment.NewLine + " Process Completed " + Environment.NewLine);
        }
        static void GetMyCityName(ILocation location)
        {
            switch (location)
            {
                case City e when e.Population == 0:
                    Console.WriteLine("Population Data is Invalid/Zero");
                    break;
                case City e when e.Population > 100:
                    Console.WriteLine("Population not in control");
                    break;
                case City e when e.Population < 100:
                    Console.WriteLine("Population under control");
                    break;
                case City e when e.Population is null:
                    Console.WriteLine("Population Data is Invalid/Null");
                    break;
                default:
                    Console.WriteLine("Invalid data");
                    break;

            }
        }
    }

    public interface ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Population { get; set; }
    }

    public class City : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Population { get; set; }
    }
}
