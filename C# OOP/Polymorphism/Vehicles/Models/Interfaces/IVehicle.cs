using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public interface IVehicle // not to be used for the moment
    {
        double FuelQuantity { get;}
        double FuelConsumption { get; }
        double TankCapacity { get; }
        string Drive(double distance);
        void Refuel(double liters);
    }
}
