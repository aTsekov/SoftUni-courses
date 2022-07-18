namespace P01.Vehicles.Models
{
    using global::Vehicles.Models;
    using Factories.Interfaces;
    using System;

    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        private double fuelConsumptionBus;

        private Vehicle()
        {
            this.FuelConsumptionModifier = 0;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : this()
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        //Full property -> Open to extension, easy can add validation
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value < 0)
                {
                    System.Console.WriteLine("Fuel must be a positive number");
                }
                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value + this.FuelConsumptionModifier;
            }
        }
        public double FuelConsumptionBus
        {
            get
            {
                return this.fuelConsumptionBus;
            }
            protected set
            {
                this.fuelConsumption = value + this.FuelConsumptionWithoutPeople;
            }
        }

        protected virtual double FuelConsumptionModifier { get; }
        protected virtual double FuelConsumptionWithoutPeople { get; }

        protected double TankCapacity
        {
            get { return this.tankCapacity; }
            set
            {

                if (value < 0)
                {
                    System.Console.WriteLine("Fuel must be a positive number");
                }
                if (value < FuelQuantity)
                {
                    FuelQuantity = 0;
                }
                this.tankCapacity = value;
            }
        }



        public virtual string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;
            if (fuelNeeded > this.FuelQuantity)
            {
                //Not Enough fuel
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public string DriveEmpty(double distance)
        {

            double fuelNeeded = distance;
            if (fuelNeeded > this.FuelQuantity)
            {
                //Not Enough fuel
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelConsumptionBus -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }


        public virtual void Refuel(double actuals, double liters)
        {


            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number"); ;
            }

            else if (TankCapacity < (actuals + FuelQuantity))
            {
                

                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }


            this.FuelQuantity += actuals;



        }


        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}