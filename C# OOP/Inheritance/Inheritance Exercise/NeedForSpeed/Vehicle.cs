using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle // THis is the parent class. Here we make a const to set a default value. Then we make the virtual property FuelConsumption = DefaultFuelConsumption. THis way when we create const with the same name in each class we can set a default value for each class. 
    {
        private const double DefaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;

            FuelConsumption = DefaultFuelConsumption;
        }
     
        public virtual double FuelConsumption { get; set; } 
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption; 
        }
    }
}
