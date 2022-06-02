using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            AddEngines(n, engines);
            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            AddCar(engines, m, cars);
            

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (car.Engine.Displacement == null)
                {
                    Console.WriteLine("Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                if (car.Engine.Efficinecy == null)
                {
                    Console.WriteLine("    Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficinecy}");
                }
                if (car.Weight == null)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                if (car.Color == null)
                {
                    Console.WriteLine($"  Color: n/a");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }

            }




        }

        private static void AddCar(List<Engine> engines, int m, List<Car> cars)
        {
            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string carModel = carInfo[0];
                string engineModel = carInfo[1];
                Car car = new Car();
                if (carInfo.Length == 2)
                {
                    foreach (var engine in engines)
                    {
                        if (engine.Model == engineModel)
                        {
                            car = new Car(carModel, engine);
                        }
                    }
                }
                else if (carInfo.Length == 3)
                {

                    if (char.IsDigit(carInfo[2][0]))
                    {
                        int weight = int.Parse(carInfo[2]);
                        foreach (var engine in engines)
                        {
                            if (engine.Model == engineModel)
                            {
                                car = new Car(carModel, engine, weight);
                            }
                        }
                    }
                    else
                    {
                        string color = carInfo[2];
                        foreach (var engine in engines)
                        {
                            if (engine.Model == engineModel)
                            {
                                car = new Car(carModel, engine, color);
                            }
                        }
                    }
                }
                else if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];
                    foreach (var engine in engines)
                    {
                        if (engine.Model == engineModel)
                        {
                            car = new Car(carModel, engine, weight, color);
                        }
                    }
                }
                cars.Add(car);
            }
        }

        private static void AddEngines(int n, List<Engine> engines)
        {
            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ").ToArray();
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                Engine engine = new Engine();


                if (engineInfo.Length == 2)
                {
                    engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else if (engineInfo.Length == 3)
                {
                    if (char.IsDigit(engineInfo[2][0]))
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];
                    engine = new Engine(model, power, displacement, efficiency);

                }
                engines.Add(engine);

            }
        }
    }
}
