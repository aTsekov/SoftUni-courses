namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Models.Weapons.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionlevel;

        public Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }
        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        public virtual int DestructionLevel
        {
            get { return destructionlevel; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }
                else if (value > 10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }
                destructionlevel = value;
            }
        }
    }
}
