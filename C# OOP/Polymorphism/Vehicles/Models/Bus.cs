namespace Vehicles.Models
{
    using P01.Vehicles.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bus : Vehicle
    {
        private double BusFuelConsumptionIncrement = 1.4;


        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumptionModifier
            => BusFuelConsumptionIncrement;

        

    }
}
