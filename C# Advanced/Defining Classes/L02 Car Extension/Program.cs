using System;

namespace CarManufacturer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity =  200;
            car.FuelConsumption = 200;
            car.Drive(2000);
            Console.WriteLine(car.WhoAmI());
        }
    }
    public class Car
    {

        public Car()
        {

        }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive (double distance)
        {
            var consumption = distance * (FuelConsumption / 100);
            if (consumption <=FuelQuantity)
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
