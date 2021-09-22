using System;
using System.Collections.Generic;
using System.Linq;
namespace AutoStore
{
    public class Search
    {
        List<Car> carInventory;
        List<Car> sortedList;
        public Search(List<Car> carInventory)
        {
            this.carInventory = carInventory;
            this.sortedList = new List<Car>();
        }

        public List<Car> SearchByPrice(int maxPrice, int minPrice)
        {
            sortedList = (from car in carInventory where car.Price <= maxPrice && car.Price >= minPrice select car).ToList();
            return sortedList;
        }
        public IEnumerable<Car> SearchByMPG(int minMPG)
        {
            sortedList = (from car in carInventory where car.Mpg >= minMPG select car).ToList();
            return sortedList;
        }

        public IEnumerable<Car> SearchByCylinders(int cylinders)
        {
            var match = (new[] { 3, 4, 5, 6, 8 }).Any(cylinder => cylinder == cylinders);
            if (!match) throw new Exception("No cars found with that many cylinders.");
            sortedList = (from car in carInventory where car.Cylinder == cylinders select car).ToList();
            return sortedList;
        }

        public IEnumerable<Car> SearchByM(int minDisplacement, int maxDisplacement)
        {
            sortedList = (from car in carInventory where car.Displacement >= minDisplacement && car.Displacement <= maxDisplacement select car).ToList();
            return sortedList;
        }

    }
}