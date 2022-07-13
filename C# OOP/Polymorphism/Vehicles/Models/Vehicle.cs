namespace P01.Vehicles.Models
{
    using global::Vehicles.Models;
    using Factories.Interfaces;

    public abstract class Vehicle 
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        private Vehicle()
        {
            this.FuelConsumptionModifier = 0;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
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
            private set
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

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                System.Console.WriteLine("Fuel must be a positive number");
            }
            
            else if (TankCapacity < (liters + FuelQuantity))
            {
                System.Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += liters;
            }


        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}