namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;
        private ICollection<IVessel> vessels; //It must be instantiated!!!
        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.CombatExperience = combatExperience;
            this.Vessels = new List<IVessel>();
        }
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
                fullName = value;
            }
        }
        public int CombatExperience
        {
            get { return combatExperience; }
            private set { combatExperience = value; }
        }

        public ICollection<IVessel> Vessels
        {
            get { return vessels; }
            private set { vessels = value; }
        }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            if (Vessels.Count != 0)
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                    //sb.AppendLine($"- {vessel.Name}");
                    //sb.AppendLine($" *Type: {vessel.GetType().Name}");
                    //sb.AppendLine($" *Armor thickness: {vessel.ArmorThickness}");
                    //sb.AppendLine($" *Main weapon caliber: {vessel.MainWeaponCaliber}");
                    //sb.AppendLine($" *Speed: {vessel.Speed} knots ");
                    //*Targets: None /{ targets}
                    //*Sonar / Submerge mode: ON / OFF" 
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
