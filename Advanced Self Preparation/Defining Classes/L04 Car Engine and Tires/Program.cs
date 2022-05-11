using System;

namespace CarManufacturer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tire [] tires = new Tire[4]
            {
                new Tire (1, 2.5),
                new Tire (2, 2.1),
                new Tire (3, 0.5),
                new Tire (4, 2.3),
            };

            Engine engine = new Engine(500, 6300);

            Car car = new Car("Lamborgini", "Urus", 2012, 250, 9, engine, tires);
        }
    }
    public class Car
    {

        public Car()// We create a ctor with default values = meaning if a car is empty, it will automatically have these values
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;

        }

        public Car(string make, string model, int year) : this() //We chain the current ctor with the empty one with this: ()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double FuelConsumption) : this(make, model, year) // we chain the second and the third ctor. This way we do not have to repead here the fields from the second. Additionally this way we can choose what values to put in the car (object) when we initiate it. 
        {
            this.FuelConsumption = FuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }
        public Car(string make, string model, int year, double fuelQuantity, double FuelConsumption, Engine engine, Tire [] tires) : this(make, model, year, fuelQuantity, FuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }


        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            var consumption = distance * (FuelConsumption / 100);
            if (consumption <= FuelQuantity)
            {

                FuelQuantity -= consumption;

            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            return $"Make: { this.Make}" +
                $" Model: { this.Model}" +
                $" Year: { this.Year}" +
                $" Fuel: { this.FuelQuantity:F2}";
        }


    }
    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this. CubicCapacity = cubicCapacity;
        }
       public int HorsePower { get; set; }
       public double CubicCapacity { get; set; }

    }
    public class Tire
    {
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;

        }
        public int Year { get; set; }
        public double Pressure { get; set; }

    }
    public class StartUp
    {

    }
}
