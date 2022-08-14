namespace PlanetWars.Models.Planets
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Planet : IPlanet
    {
        private UnitRepository units; //THIS MUST BE INSTANTIATED
        private WeaponRepository weapons;
        private string name;
        private double budget;
        private double militaryPower;
        private Planet planet;
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.MilitaryPower = militaryPower;
            units = new UnitRepository();
            weapons = new WeaponRepository();
            
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get { return militaryPower; }
            private set
            {

                //militaryPower = (units.Models.Sum(u => u.EnduranceLevel)) + weapons.Models.Sum(w => w.DestructionLevel);


                //if (units.Models.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
                //{
                //    militaryPower = militaryPower * 1.3;
                //}
                //if (weapons.Models.Any(w => w.GetType().Name == "NuclearWeapon"))
                //{
                //    militaryPower = Math.Round(militaryPower * 1.45, 3);
                //}
                militaryPower = value;

            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var item in Army)
            {
                item.IncreaseEndurance();
            }
        }
        public void Spend(double amount)
        {
            budget -= amount;
            if (budget < amount)
            {
                throw new InvalidOperationException("Budget too low!");
            }
        }
        public void Profit(double amount)
        {
            budget += amount;
        }
        public string PlanetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            if (Army.Count == 0)
            {
                sb.AppendLine("--Forces: No units");
            }
            else
            {
                sb.AppendLine($"--Forces: {string.Join(", ", Army)}");
            }
            if (Weapons.Count == 0)
            {
                sb.AppendLine("--Forces: None");
            }
            else
            {
                sb.AppendLine($"--Forces: {string.Join(", ", Weapons)}");
            }
            sb.AppendLine($"--Military Power: {MilitaryPower}");
            return sb.ToString().TrimEnd();

        }






    }
}
