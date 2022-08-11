namespace SpaceStation.Models
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    //CHECK IF PROPS SETTERS IN BASE CLASS SHOULD BE PROTECTED OR PRIVATE
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;
        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
            
        }
        
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                oxygen = value;
            }

        }

        public bool CanBreath => oxygen > 0;

        public IBag Bag => bag;

        public virtual void Breath()
        {
            Oxygen -= 10;
            if (oxygen < 0)
            {
                oxygen = 0;
            }
        }
    }
}
