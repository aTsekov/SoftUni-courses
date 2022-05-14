using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                
                string[] info = Console.ReadLine().Split(" ");

                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];

                List<Tire> tires = new List<Tire>();
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                for (int t = 5; t <= 12; t+=2)
                {
                    double tirePressure = double.Parse(info[t]);
                    int tireYear = int.Parse(info[t+1]);

                    Tire tire = new Tire(tireYear, tirePressure);
                    tires.Add(tire);
                }
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);

            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {


                List<Car> fragile = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure <1)).ToList();
                foreach (var item in fragile)
                {
                    Console.WriteLine(item.Model);
                }

            }
            else if (command == "flammable")
            {
                List<Car> flammable = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250).ToList();
                foreach (var item in flammable)
                {
                    Console.WriteLine(item.Model);
                }
            }

            
        }
    }
}
