using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double Travelled { get; set; }

        public void Drive( double amountOfKm)
        {
            double neededFuel = FuelConsumptionPerKilometer * amountOfKm;
            

            if (FuelAmount >= neededFuel) //we can drive
            {
                FuelAmount -= neededFuel;
                Travelled += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

    
}
