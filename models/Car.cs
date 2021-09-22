using System;
namespace AutoStore
{
    public class Car
    {
        private double _mpg { get; }
        private double _cylinders;
        private double _displacement;
        private double _horsepower;
        private double _weight;
        private double _acceleration;
        private int _modelYear;
        private int _origin;
        private string _carName;
        private decimal _price;


        public Car(string line)
        {
            var dataFields = line.Split(',');
            this._mpg = Double.Parse(dataFields[0]);
            this._cylinders = Double.Parse(dataFields[1]);
            this._displacement = Double.Parse(dataFields[2]);
            this._horsepower = Double.Parse(dataFields[3]);
            this._weight = Double.Parse(dataFields[4]);
            this._acceleration = Double.Parse(dataFields[5]);
            this._modelYear = Int16.Parse(dataFields[6]);
            this._origin = Int16.Parse(dataFields[7]);
            this._carName = dataFields[8];
            //code to RNG price
            this._price = Convert.ToDecimal(new Random().Next(10000, 20001));
        }

        public double Mpg { get { return _mpg; } }
        public double Cylinder { get { return _cylinders; } }
        public double Displacement { get { return _displacement; } }
        public double Horsepower { get { return _horsepower; } }
        public double Weight { get { return _weight; } }
        public double Acceleration { get { return _acceleration; } }
        public int ModelYear { get { return _modelYear; } }
        public int Origin { get { return _origin; } }
        public string CarName { get { return _carName; } }
        public decimal Price { get { return _price; } }
    }
}