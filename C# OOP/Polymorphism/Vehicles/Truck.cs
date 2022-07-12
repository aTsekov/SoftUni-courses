using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {

        private const double fuelConsumption = 1.6;
        private const double RefuleCoefficient = 0.95;

        public Truck(double fueltQuantity, double fuelConsumption) : base(fueltQuantity, fuelConsumption)
        {
        }
        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                base.FuelConsumption = value + fuelConsumption;
            }
        }
        public override void Refuel(double liters)
        {
            base.Refuel(liters * RefuleCoefficient);
        }
    }
}
