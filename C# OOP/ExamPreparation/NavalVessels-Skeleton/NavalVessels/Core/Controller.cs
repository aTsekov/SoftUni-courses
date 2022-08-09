namespace NavalVessels.Core
{
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {

        private VesselRepository vessels;
        private ICollection<ICaptain> captains;
        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            var captain = new Captain(fullName);
            if (captains.Any( c => c.FullName == fullName))
            {
                return $"Captain {fullName} is already hired.";
            }
            captains.Add(captain);
            
            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;
            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed, 200);

            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed, 300);

            }
            else
            {
                return "Invalid vessel type.";
            }
            if (vessels.Models.Any( a => a.Name == name))
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }

            vessels.Add(vessel);
            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var vessel1 = vessels.Models.FirstOrDefault(v => v.Name == selectedVesselName);
            var captain1 = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            if (!captains.Any(c => c.FullName == selectedCaptainName))
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }
            if (!vessels.Models.Any(v => v.Name == vessel1.Name))
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            if (vessel1.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied."; // Potential error. 
            }
            if (captains.Any(c => c.FullName == selectedCaptainName))
            {
                captain1.AddVessel(vessel1);
                vessel1.Captain = captain1;
                return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
            }
            return null;
        }
        public string CaptainReport(string captainFullName)
        {
            var cap = captains.FirstOrDefault( c => c.FullName == captainFullName);
            var str = cap.Report();
            return str;
        }
        public string VesselReport(string vesselName)
        {
            var ves = vessels.Models.FirstOrDefault(v => v.Name == vesselName);
            var str = ves.ToString();
            return str;
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var ves = vessels.Models.FirstOrDefault(v => v.Name == vesselName);

            if (!vessels.Models.Any(v => v.Name == vesselName))
            {
                return $"Vessel {vesselName} could not be found.";
            }
            else if (ves.GetType().Name == "Battleship")
            {
                
                Battleship battleShip = (Battleship)ves;
                battleShip.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
                    
            }
            else
            {
                Submarine sub = (Submarine)ves;
                sub.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }

        }
        public string ServiceVessel(string vesselName)
        {
            var ves = vessels.Models.FirstOrDefault(v => v.Name == vesselName);

            if (!vessels.Models.Any(v => v.Name == vesselName))
            {
                return $"Vessel {vesselName} could not be found.";
            }
            else
            {
                ves.RepairVessel();
                return $"Vessel {vesselName} was repaired.";
            }
        }
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacking = vessels.Models.FirstOrDefault(v => v.Name == attackingVesselName);
            var defending = vessels.Models.FirstOrDefault(v => v.Name == defendingVesselName);
            if (!vessels.Models.Any(v => v.Name == attackingVesselName) )
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if ( !vessels.Models.Any(v => v.Name == defendingVesselName))
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }
            if (attacking.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (defending.ArmorThickness == 0)
            {
                return$"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }
            attacking.Attack(defending);
            attacking.Captain.IncreaseCombatExperience();
            defending.Captain.IncreaseCombatExperience();
            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defending.ArmorThickness}.";

        }


        




        

        

        
    }
}
