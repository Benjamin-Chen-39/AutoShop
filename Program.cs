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

            int selection;
            Console.WriteLine("Welcome to AutoStore!!! To browse the cars for sale, enter 1. To view car analytical data, enter 2.");
            selection = Convert.ToInt16(Console.ReadLine());

            if (selection == 1)
            {
                Console.WriteLine("How much is in your account?");
                decimal initialAmount = Convert.ToDecimal(Console.ReadLine());
                var CurrentUser = new User(initialAmount);

                int menuFilter = 0;

                Console.Write("To view all cars, enter 1.\nTo set a price range, enter 2.\nTo set a minimum MPG, enter 3.");
                Console.Write("To search by number of cylinders, enter 4.\nTo search by engine displacement, enter 5.\nTo set a minimum horsepower, enter 6.");
                Console.WriteLine("To search by weight, enter 7.\nTo search by year, enter 8.\nTo search by origin, enter 9.\nTo search by keyword, enter 0.\nTo exit, enter -1.");
                menuFilter = Convert.ToInt16(Console.ReadLine());

                switch (menuFilter)
                {
                    case 1:
                        foreach (var car in CarInventory)
                            Console.WriteLine($"{car}");
                        break;
                    case 2:
                        foreach (var car in searcher.SearchByPrice(15000, 17000))
                            Console.WriteLine($"cars by price: {car}");
                        break;
                    case 3:
                        foreach (var car in searcher.SearchByMPG(35))
                            Console.WriteLine($"Cars by MPG: {car}");
                        break;
                    case 4:
                        foreach (var car in searcher.SearchByCylinders(5))
                            Console.WriteLine($"Cars by Cylinders: {car}");
                        break;
                    case 5:
                        foreach (var car in searcher.SearchByDisplacement(400, 500))
                            Console.WriteLine($"Cars by displacement: {car}");
                        break;
                    case 6:
                        foreach (var car in searcher.SearchByHP(200))
                            Console.WriteLine($"Cars by HP: {car}");
                        break;
                    case 7:
                        foreach (var car in searcher.SearchByWeight(2000, 5000))
                            Console.WriteLine($"Cars by weight: {car}");
                        break;
                    case 8:
                        foreach (var car in searcher.SearchByYear(76))
                            Console.WriteLine($"Cars by year: {car}");
                        break;
                    case 9:
                        foreach (var car in searcher.SearchByOrigin(3))
                            Console.WriteLine($"Cars by origin: {car}");
                        break;
                    case 0:
                        foreach (var car in searcher.SearchByKeyword("mustang"))
                            Console.WriteLine($"Cars by model: {car}");
                        break;
                }
            }//end of part 1

            else if (selection == 2)
            {
                //check avg mpg
                var analytics = new Analytics(CarInventory);
                Console.WriteLine($"Average MPG for all cars: {analytics.GetAverageMPG()}");

                Console.Write("Unique cylinders found: ");
                foreach (var cylinder in analytics.GetUniqueCylinders())
                    Console.Write($"{cylinder} ");
                Console.WriteLine();

                Console.WriteLine("Car(s) with the largest displacement: ");
                foreach (var car in analytics.GetLargestDisplacement())
                    Console.WriteLine($"{car}");
                Console.WriteLine();

                Console.WriteLine("Car(s) with the smallest displacement: ");
                foreach (var car in analytics.GetSmallestDisplacement())
                    Console.WriteLine($"{car}");
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
                foreach (var car in groups)
                {
                    Console.WriteLine($"{car}");
                }
            }//end of part 2

            Console.WriteLine("Thank you for visting AutoStore, have a nice day.");
        }//end of Main
    }
}
