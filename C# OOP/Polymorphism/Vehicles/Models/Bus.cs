namespace Vehicles.Models
{
    using P01.Vehicles.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bus : Vehicle
    {
        private  double BusFuelConsumptionIncrement = 1.4;
        

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumptionModifier
            => BusFuelConsumptionIncrement;
        public void  DriveEmpty(double distance)
        {
            BusFuelConsumptionIncrement = 0;
            Drive(distance);

        }
        public override string Drive(double distance)
        {
            BusFuelConsumptionIncrement = 1.4;
            return base.Drive(distance);
        }
    }
}
