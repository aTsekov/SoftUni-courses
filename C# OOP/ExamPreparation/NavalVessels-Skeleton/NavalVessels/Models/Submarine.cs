namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode = false;
        public Submarine(string name, double mainWeaponCaliber, double speed, double armorThickness) 
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
            this.ArmorThickness = 200;
            this.SubmergeMode = submergeMode;
        }
        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }
        public  void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                SubmergeMode = true; //Activate the sonarMode
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;

            }
            else if (SubmergeMode == true)
            {

                SubmergeMode = false; //Desactivate the sonarMode
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }
        
        public override void RepairVessel()
        {
            if (this.ArmorThickness < 200)
            {
                this.ArmorThickness = 200;
            }
        }
        public override string ToString()
        {
            string submergeCurrMode = SubmergeMode == false ? "OFF" : "ON";
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {submergeCurrMode}");
            return sb.ToString().TrimEnd();
        }
    }
}
