using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tiresCmd = Console.ReadLine();
            
            // this is the create the new tires >> each tire has an year and pressure

            List<Tire[]> tiresList = new List<Tire[]>();
            while (tiresCmd != "No more tires")
            {
                
                string[] tiresInfo = tiresCmd.Split(" ");

                int firstTireYear = int.Parse(tiresInfo[0]);
                double firstTirePressute = double.Parse(tiresInfo[1]);
                int secondTireYear = int.Parse(tiresInfo[2]);
                double secondTirePressute = double.Parse(tiresInfo[3]);
                int thirdTireYear = int.Parse(tiresInfo[4]);
                double thirdTirePressute = double.Parse(tiresInfo[5]);
                int forthTireYear = int.Parse(tiresInfo[6]);
                double forthTirePressute = double.Parse(tiresInfo[7]);

                Tire [] firstSetOfTires = new Tire[4]
                {
                    new Tire(firstTireYear,firstTirePressute),
                    new Tire(secondTireYear, secondTirePressute),
                    new Tire (thirdTireYear, thirdTirePressute),
                    new Tire (forthTireYear, forthTirePressute)
                };
                tiresList.Add(firstSetOfTires);

                tiresCmd = Console.ReadLine();
            }
            List<Engine> engineList = new List<Engine>();
            string engineCmd = Console.ReadLine();
            while (engineCmd != "Engines done")
            {
                string[] engineInfo = engineCmd.Split(" ");

                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine engine1 = new Engine(horsePower, cubicCapacity);
                engineList.Add(engine1);

                engineCmd = Console.ReadLine();
            }


            string carCmd = Console.ReadLine();
            List<Car> carsList = new List<Car>();
            while (carCmd != "Show special")
            {
                string[] carInfo = carCmd.Split(" ");  

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                int   horsePower = int.Parse (carInfo[3]);
                int fuelConsumption = int.Parse (carInfo[4]);
                int engineIndex = int.Parse (carInfo[5]);
                int tireIndex = int.Parse (carInfo[6]);

                Car car = new Car(make,model, year,horsePower,fuelConsumption, engineList[engineIndex], tiresList[tireIndex]);
                carsList.Add(car);
                carCmd = Console.ReadLine();
            }

            foreach (var car in carsList)
            {
                int distance = 20;
                car.Drive(distance);
            }
            foreach (var car in carsList)
            {
                double tirePressure = car.Tires[0].Pressure + car.Tires[1].Pressure+ car.Tires[2].Pressure+ car.Tires[3].Pressure; 

                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && tirePressure >= 9 && tirePressure <= 10)
                {
                    Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                }
            }



        }
    }
    public class Car
    {

        public Car()
        {
        }

        public Car(string make, string model, int year) : this() //We chain the current ctor with the empty one with this: ()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double FuelConsumption) : this(make, model, year) // we chain the second and the third ctor. This way we do not have to repead here the fields from the second. Additionally this way we can choose what values to put in the car (object) when we initiate it. 
        {
            this.FuelConsumption = FuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }
        public Car(string make, string model, int year, double fuelQuantity, double FuelConsumption, Engine engine, Tire[] tires) : this(make, model, year, fuelQuantity, FuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }


        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            var consumption = distance * (FuelConsumption / 100);
            if (consumption <= FuelQuantity)
            {

                FuelQuantity -= consumption;

            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
    }

    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

    }
    public class Tire
    {
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;

        }
        public int Year { get; set; }
        public double Pressure { get; set; }

    }
    public class StartUp
    {

    }
}
