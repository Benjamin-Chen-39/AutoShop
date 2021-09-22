using System;
using System.Collections.Generic;
using System.Linq;
namespace AutoStore
{
    public class Analytics
    {
        private List<Car> _carInventory;


        public Analytics(List<Car> cars)
        {
            _carInventory = cars;
        }
        public double GetAverageMPG()//average MPG
        {
            return (from car in _carInventory select car.Mpg).Average();
        }

        public IEnumerable<double> GetUniqueCylinders()
        {
            return (from car in _carInventory select car.Cylinder).Distinct();
        }
        //unique set of cylinders

        public IEnumerable<Car> GetLargestDisplacement()
        {
            var Max = (from car in _carInventory select car.Displacement).Max();
            return from car in _carInventory where car.Displacement == Max select car;
        }
        public IEnumerable<Car> GetSmallestDisplacement()
        {
            var Min = (from car in _carInventory select car.Displacement).Min();
            return from car in _carInventory where car.Displacement == Min select car;
        }

        public double GetAverageHPByYear(int year)
        {
            var match = (new[] { 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82 }).Any(yr => yr == year);
            if (!match) throw new Exception("Invalid year");
            return (from car in _carInventory where car.ModelYear == year select car.Horsepower).Average();
        }

        public int CountInventory()
        {
            return _carInventory.Count();
        }

        public IEnumerable<(int origin, double averageMPG)> GetAvgMPGByOrigin()
        {
            return from car in _carInventory
                   group car by car.Origin into grouped
                   select (origin: grouped.Key, averageMPG: (from car in grouped select car.Mpg).Average());
        }

    }
}