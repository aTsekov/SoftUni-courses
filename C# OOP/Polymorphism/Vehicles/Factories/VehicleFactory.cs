namespace P01.Vehicles.Factories
{
    using System;
    using global::Vehicles.Models;
    using Interfaces;
    using Models;

    public class VehicleFactory : IVehicleFactory //Create the vehicle with the given data from the StartUp
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle;
            

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                if (fuelQuantity > tankCapacity)
                {
                    vehicle = new Bus(0, fuelConsumption, tankCapacity);
                }
                else
                {
                    vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                }

            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }


    }
}