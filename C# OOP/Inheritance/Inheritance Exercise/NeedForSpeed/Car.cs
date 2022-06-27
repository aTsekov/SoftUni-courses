using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3; //Here we state that the default fuel consumption is 3. THen we override the value of FuelConsumption because it is virtual poperty. 
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption => DefaultFuelConsumption; 
    }
}
