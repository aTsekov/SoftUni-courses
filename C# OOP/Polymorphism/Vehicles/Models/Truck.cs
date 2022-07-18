namespace P01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionIncrement = 1.6;
        private const double RefuelCoeffiecient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption,double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumptionModifier
            => TruckFuelConsumptionIncrement;

        public override void Refuel(double actualLitters, double liters)
        {
            //liters *= RefuelCoeffiecient;
             actualLitters = liters * RefuelCoeffiecient;
            base.Refuel(actualLitters,liters);
            
            
           
        }
    }
}