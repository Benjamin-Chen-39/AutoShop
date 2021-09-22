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

        public List<Car> SearchByPrice(int minPrice, int maxPrice)
        {
            sortedList = (from car in carInventory where car.Price <= maxPrice && car.Price >= minPrice select car).ToList();
            if (sortedList.Count == 0) throw new Exception("No cars found.");
            return sortedList;
        }
        public IEnumerable<Car> SearchByMPG(int minMPG)
        {
            sortedList = (from car in carInventory where car.Mpg >= minMPG select car).ToList();
            if (sortedList.Count == 0) throw new Exception("No cars found.");
            return sortedList;
        }

        public IEnumerable<Car> SearchByCylinders(int cylinders)
        {

            sortedList = (from car in carInventory where car.Cylinder == cylinders select car).ToList();
            if (sortedList.Count == 0) throw new Exception("No cars found.");
            return sortedList;
        }

        public IEnumerable<Car> SearchByDisplacement(int minDisplacement, int maxDisplacement)
        {
            sortedList = (from car in carInventory where car.Displacement >= minDisplacement && car.Displacement <= maxDisplacement select car).ToList();
            if (sortedList.Count == 0) throw new Exception("No cars found.");
            return sortedList;
        }

        public IEnumerable<Car> SearchByHP(int horsepower)
        {
            sortedList = (from car in carInventory where car.Horsepower >= horsepower select car).ToList();
            if (sortedList.Count == 0) throw new Exception("No cars found.");
            return sortedList;
        }

        public IEnumerable<Car> SearchByWeight(int minWeight, int maxWeight)
        {
            sortedList = (from car in carInventory where car.Displacement >= minWeight && car.Displacement <= maxWeight select car).ToList();
            if (sortedList.Count == 0) throw new Exception("No cars found.");
            return sortedList;
        }
        public IEnumerable<Car> SearchByKeyword(string keyword)
        {
            sortedList = (from car in carInventory where car.CarName.Contains(keyword) select car).ToList();
            if (sortedList.Count == 0) throw new Exception("No cars found.");
            return sortedList;
        }
        public IEnumerable<Car> SearchByYear(int year)
        {
            sortedList = (from car in carInventory where car.ModelYear == year select car).ToList();
            if (sortedList.Count == 0) throw new Exception("No cars found.");
            return sortedList;
        }
        public IEnumerable<Car> SearchByOrigin(int origin)
        {
            sortedList = (from car in carInventory where car.Origin == origin select car).ToList();
            if (sortedList.Count == 0) throw new Exception("No cars found.");
            return sortedList;
        }


    }
}