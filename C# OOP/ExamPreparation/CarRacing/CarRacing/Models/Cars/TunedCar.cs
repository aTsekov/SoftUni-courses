namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TunedCar : Car, ICar
    {
        private double adjustedHorsePower;
        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, 65, 7.5)
        {
        }
        public override void Drive()
        {
            adjustedHorsePower = HorsePower / 1.03;
            HorsePower = (int)Math.Round(adjustedHorsePower);
            base.Drive();
        }
    }
}
