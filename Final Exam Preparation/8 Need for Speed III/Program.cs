using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int TANK = 75;
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,Cars> carsDict = new Dictionary<string,Cars>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                string car = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                Cars carObj = new Cars (car, mileage, fuel);
                carsDict[car] = carObj;
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commArgs = command.Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries);
                string commandType = commArgs[0];
                if (commandType == "Drive")
                {
                    string carModel = commArgs[1];
                    int distanceToDrive = int.Parse(commArgs[2]);
                    int neededFuel = int.Parse(commArgs[3]);

                    if (carsDict[carModel].Fuel < neededFuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else if (carsDict[carModel].Fuel >= neededFuel)
                    {
                        carsDict[carModel].Mileage += distanceToDrive;
                        carsDict[carModel].Fuel -= neededFuel;
                        Console.WriteLine($"{carModel} driven for {distanceToDrive} kilometers. {neededFuel} liters of fuel consumed.");
                    }
                    if (carsDict[carModel].Mileage > 100000)
                    {
                        carsDict.Remove(carModel);
                        Console.WriteLine($"Time to sell the {carModel}!");
                    }

                }
                else if (commandType == "Refuel")
                {
                    string carModel = commArgs[1];
                    int refillFuel = int.Parse(commArgs[2]);
                    if (carsDict[carModel].Fuel + refillFuel > TANK)
                    {
                        int difference = TANK - carsDict[carModel].Fuel;
                        carsDict[carModel].Fuel = TANK;

                        Console.WriteLine($"{carModel} refueled with {difference} liters");
                        continue;
                    }
                    else
                    {
                        carsDict[carModel].Fuel += refillFuel;
                    }
                    Console.WriteLine($"{carModel} refueled with {refillFuel} liters");
                    

                }
                else if (commandType == "Revert")
                {
                    string carModel = commArgs[1];
                    int km = int.Parse(commArgs[2]);
                    carsDict[carModel].Mileage -= km;
                    if (carsDict[carModel].Mileage < 10000)
                    {
                        carsDict[carModel].Mileage = 10000;
                        continue;
                    }
                    Console.WriteLine($"{carModel} mileage decreased by {km} kilometers");

                }

            }
            foreach (var car in carsDict)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
                
            }

        }
        class Cars
        {
            public Cars( string car, int mileage,int fuel)
            {
                this.Car = car;
                this.Mileage = mileage;
                this.Fuel = fuel;
            }
            public string Car { get; set; }

            public int Mileage { get; set; }

            public int Fuel { get; set; }
        }
    }
}
