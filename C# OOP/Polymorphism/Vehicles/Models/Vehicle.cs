using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles 
{
    public  abstract class Vehicle 
    {
        private double fuelQuantity;
        private double fuelConsumption;
        public Vehicle()
        {

        }
        public Vehicle(double fueltQuantity, double  fuelConsumption)
        {
            this.FuelQuantity = fueltQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            private set { this.fuelQuantity = value; }
        }
        public  virtual double FuelConsumption { get; protected set; } // liters per km
        public  void Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;
            if (fuelNeeded > this.FuelQuantity)
            {
                // not EnoughFuel
                Console.WriteLine($"{this.GetType().Name} needs refueling"); 
            }
            this.FuelQuantity -= fuelNeeded;
             Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
