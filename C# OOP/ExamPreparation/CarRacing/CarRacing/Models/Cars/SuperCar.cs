namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SuperCar : Car, ICar
    {
        public SuperCar(string make, string model, string VIN, int horsePower, ) 
            : base(make, model, VIN, horsePower, 80, 10)
        {
        }
    }
}
