namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode = false;
        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
            this.ArmorThickness = 300;
            this.SonarMode = sonarMode;
        }
        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }
        public void ToggleSonarMode()
        {
            if (SonarMode == false)
            {
                SonarMode = true; //Activate the sonarMode
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;

            }
            else if (SonarMode == true)
            {

                SonarMode = false; //Desactivate the sonarMode
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 300)
            {
                this.ArmorThickness = 300;
            }
        }
        public override string ToString()
        {
            string sonnarCurrMode = SonarMode == false ? "OFF" : "ON";
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {sonnarCurrMode}");
            return sb.ToString().TrimEnd();
        }
    }
}
