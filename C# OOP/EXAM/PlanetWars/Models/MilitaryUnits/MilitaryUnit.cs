namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1;
        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = enduranceLevel;
        }
        public double Cost
        {
            get { return cost; }
            private set { cost = value; }
        }

        public int EnduranceLevel
        {
            get { return enduranceLevel;}
            private set { enduranceLevel = value; }
        }

        public void IncreaseEndurance()
        {
            enduranceLevel++;

            if (enduranceLevel > 20)
            {
                enduranceLevel = 20;
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
        }
    }
}
