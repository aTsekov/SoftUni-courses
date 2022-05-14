using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {

                string [] carInfo = Console.ReadLine().Split(' ');

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);
                Car car = new Car (model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine ()) != "End")
            {
                string[] info = input.Split(" ");
                string command = info[0];
                string carModel = info[1];
                double amountOfKm = double.Parse(info[2]);

                cars.Where(c => c.Model == carModel).ToList().ForEach(c => c.Drive(amountOfKm));
                // get teh car from the list that is = to the carModel and then each car calls the method Drive. 
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.Travelled}");
            }

        }
    }
}
