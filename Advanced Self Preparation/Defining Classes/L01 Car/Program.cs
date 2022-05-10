using System;
using CarManufacturer;
using System.Linq;

namespace CarManufacturer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Model = "MK3";
            car.Make = "VW";
            car.Year = 1992;



            Console.WriteLine($"Make: {car.Model}\nModel: {car}\nYear: {car}");

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



    }
    public class StartUp
    {

    }
}
