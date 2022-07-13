namespace P01.Vehicles
{
    using System;

    using Core;
    using Factories;
    using Factories.Interfaces;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialization of the application
            string[] carData = Console.ReadLine() // Read the input
                .Split();
            string[] truckData = Console.ReadLine()
                .Split();
            string[] busData = Console.ReadLine()
                .Split();

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory
                .CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
            Vehicle truck = vehicleFactory
                .CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(carData[3])); //the two vehicles are created
            Vehicle bus = vehicleFactory
                .CreateVehicle(busData[0], double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3])); //the two vehicles are created

            IEngine engine = new Engine(car, truck,bus);
            engine.Start(); //Starts business logic
        }
    }
}