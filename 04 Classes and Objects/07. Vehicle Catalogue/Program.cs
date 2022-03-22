using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    class Trucks
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }
    class Cars
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }
    class CatalogVehicle
    {
        public CatalogVehicle()
        {
            this.Trucks = new List<Trucks>();
            this.Cars = new List<Cars>();
        }

        public List<Trucks> Trucks { get; set; }
        public List<Cars> Cars { get; set; }
    }
    
    class Program
    {

        static void Main(string[] args)
        {
            CatalogVehicle catalog = new CatalogVehicle();
            string input = Console.ReadLine();
            string[] command = input.Split('/', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "end")
            {
                string type = command[0];
                string brand = command[1];
                string model = command[2];
                int horsePowerOrWeight = int.Parse(command[3]);

                if (type == "Car")
                {
                    Cars carsObject = new Cars()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePowerOrWeight

                        
                    };
                    catalog.Cars.Add(carsObject);
                }
                else if (type == "Truck")
                {
                    Trucks trucksOnject = new Trucks()
                    {
                        Brand = brand,
                        Model= model,
                        Weight = horsePowerOrWeight
                    };
                    catalog.Trucks.Add(trucksOnject);
                }


                

                input = Console.ReadLine();
                command = input.Split('/', StringSplitOptions.RemoveEmptyEntries);
            }

            catalog.Cars = catalog.Cars.OrderBy(x => x.Brand).ToList();
            catalog.Trucks = catalog.Trucks.OrderBy(x => x.Brand).ToList();

            if (catalog.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");

                foreach (var car in catalog.Cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");

                foreach (var truck in catalog.Trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }
}
