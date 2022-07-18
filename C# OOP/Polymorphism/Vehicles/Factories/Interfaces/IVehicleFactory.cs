namespace P01.Vehicles.Factories.Interfaces
{
    using Models;

    public interface IVehicleFactory
    {
        
        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity); //Forces the the VehicleFactory class to have a method that accepts the described parameters. 
    }
}