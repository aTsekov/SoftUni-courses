using System;

namespace CarManufacturer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car fisrtCar = new Car();
            Car secondCar = new Car(make,model,year);
            Car thirdCar = new Car(make,model,year, fuelQuantity,fuelConsumption);

        }
    }
    public class Car
    {

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;

        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double FuelConsumption) : this (make, model, year)
        {
            this.FuelConsumption = FuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }
        

        
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

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
    public class StartUp
    {

    }
}
