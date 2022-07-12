using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double fuelConsumption = 0.9;

        public Car(double fueltQuantity, double fuelConsumption) : base(fueltQuantity, fuelConsumption)
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
    }
}
