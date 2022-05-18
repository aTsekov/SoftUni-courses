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

            Car fisrtCar = new Car(); // The first car is with the default values
            Car secondCar = new Car(make,model,year);// THe second car has only the values only from the second constructor
            Car thirdCar = new Car(make,model,year, fuelQuantity,fuelConsumption);// The 3rd car has the values from all of the ctor's apart from the defaul ones.

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
        public Car(string make, string model, int year, double fuelQuantity, double FuelConsumption) : this (make, model, year) // we chain the second and the third ctor. This way we do not have to repead here the fields from the second. Additionally this way we can choose what values to put in the car (object) when we initiate it. 
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
