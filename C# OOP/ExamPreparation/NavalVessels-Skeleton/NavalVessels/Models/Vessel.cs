namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armotThickness = 0;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets; //DO NOT FORGET TO INITIALIZE IT in teh CTOR - ALL of the FIELDS maybe??

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            captain = null;
            this.Targets = new List<string>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get { return this.captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                this.captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return this.armotThickness; }
            set { this.armotThickness = value; }
        }

        public double MainWeaponCaliber
        {
            get { return this.mainWeaponCaliber; }
            protected set { this.mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return this.speed; }
            protected set { this.speed = value; }
        }

        public ICollection<string> Targets
        {
            get { return this.targets;}
            private set { this.targets = value; }
        }

        public void Attack(IVessel target) //This is absolutely wrong!
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }

            
            
            target.ArmorThickness -= this.MainWeaponCaliber;
            if (ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            targets.Add(target.Name);


        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            if (Targets.Count == 0)
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(", ", Targets)}");
            }



            return sb.ToString().TrimEnd();
        }

    }
}
