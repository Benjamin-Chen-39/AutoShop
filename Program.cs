using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace AutoStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var CarInventory = new List<Car>();
            string line;


            System.IO.StreamReader file =
                new System.IO.StreamReader(@"./data/auto-mpg.csv");
            while ((line = file.ReadLine()) != null)
            {
                //code to initialize Car List
                CarInventory.Add(new Car(line));
            }
            file.Close();
            var searcher = new Search(CarInventory);

            foreach (var car in searcher.SearchByPrice(17000, 15000))
                Console.WriteLine($"cars by price: {car.CarName} {car.Price}");

            foreach (var car in searcher.SearchByMPG(25))
                Console.WriteLine($"Cars by MPG: {car.CarName} {car.Mpg}");

            try
            {
                foreach (var car in searcher.SearchByCylinders(5))
                    Console.WriteLine($"Cars by MPG: {car.CarName} {car.Cylinder}");
            }
            catch (Exception ex) {
                 Console.WriteLine($"Exception caught: {ex.Message}");
                  }

            //check avg mpg
            var analytics = new Analytics(CarInventory);
            Console.WriteLine($"Average MPG for all cars: {analytics.GetAverageMPG()}");

            Console.Write("Unique cylinders found: ");
            foreach (var cylinder in analytics.GetUniqueCylinders())
                Console.Write($"{cylinder} ");
            Console.WriteLine();

            Console.Write("Car(s) with the largest displacement: ");
            foreach (var car in analytics.GetLargestDisplacement())
                Console.Write($"{car.CarName }");
            Console.WriteLine();

            Console.Write("Car(s) with the smallest displacement: ");
            foreach (var car in analytics.GetSmallestDisplacement())
                Console.Write($"{car.CarName }");
            Console.WriteLine();

            try
            {
                int year;
                Console.Write("Input a year (70-82, for 1970-1982) to see average horsepower for cars made that year: ");
                year = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine($"Average HP in year 19{year}: {analytics.GetAverageHPByYear(year)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }

            Console.WriteLine($"Number of cars in inventory: {analytics.CountInventory()}");

            var groups = analytics.GetAvgMPGByOrigin();
            Console.WriteLine("Average MPG for cars by origin, where 1 is cars made in the US, 2 is cars made in Mexico, and 3 is cars made in Canada");
            foreach (var g in groups)
            {
                Console.WriteLine($"{g.origin}: {g.averageMPG}");
            }


        }//end of Main
    }
}
