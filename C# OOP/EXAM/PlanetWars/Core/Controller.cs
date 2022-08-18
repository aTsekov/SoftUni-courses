namespace PlanetWars.Core
{
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            //TO INITIALISE EVERYTHING like classes and collection!!!

            planets = new PlanetRepository();

        }
        public string CreatePlanet(string name, double budget)
        {
            

            if (planets.Models.Any( p => p.Name == name))
            {
                return $"Planet {name} is already added!";
            }
            var planet = new Planet(name, budget);
            planets.AddItem(planet);
            return $"Successfully added Planet: {name}";
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit unit;
            var planet = planets.FindByName(planetName);
            if (planets.FindByName( planetName) == null)
            {
                throw new InvalidOperationException( $"Planet {planetName} does not exist!");
            }
            

            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            if (planet.Army.Any( u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            planets.FindByName(planetName).AddUnit(unit);
            planets.FindByName(planetName).Spend(unit.Cost);
            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IWeapon weapon;
            
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }
            if (planets.FindByName(planetName).Weapons.Any( w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }
            planets.FindByName(planetName).AddWeapon(weapon);
            planets.FindByName(planetName).Spend(weapon.Price);
            return $"{planetName} purchased {weaponTypeName}!";

        }

        public string SpecializeForces(string planetName)
        {
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (planets.FindByName(planetName).Army.Count == 0)
            {
                throw new InvalidOperationException($"No units available for upgrade!");
            }
            planets.FindByName(planetName).Spend(1.25);
            foreach (var item in planets.FindByName(planetName).Army)
            {
                item.IncreaseEndurance();
            }
            return $"{planetName} has upgraded its forces!";
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planet1 = planets.FindByName(planetOne);
            var planet2 = planets.FindByName(planetTwo);
            string planet1Winner = planet1.Name;
            string planet2Winner = planet2.Name;
            bool planet1Win = false;
            bool planet2Win = false;
            bool IsPlanet1Nuclear = planet1.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
            bool IsPlanet2Nuclear = planet2.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (IsPlanet1Nuclear)
                {
                    planet1Win = true;
                }
                else if (IsPlanet2Nuclear)
                {
                    planet2Win = true;
                }
            }
            else if (planet1.MilitaryPower == planet2.MilitaryPower && IsPlanet1Nuclear == true && IsPlanet2Nuclear == true 
                || IsPlanet1Nuclear ==  false && IsPlanet2Nuclear == false)
            {
                planet1.Spend(planet1.Budget / 2);
                planet2.Spend(planet2.Budget / 2);
                return $"The only winners from the war are the ones who supply the bullets and the bandages!";
            }
            if (planet1Win == true)
            {
                planet1.Spend(planet1.Budget / 2);
                planet1.Profit(planet2.Budget / 2);
                var sumOfForcesCostsOfLoosing = planet2.Army.Sum(s => s.Cost);
                var sumOfweaponsPriceOfLoosing = planet2.Weapons.Sum(s => s.Price);
                planet1.Profit(sumOfweaponsPriceOfLoosing);
                planet1.Profit(sumOfForcesCostsOfLoosing);
                planets.RemoveItem(planet2.Name);
                return $"{planet1.Name} destructed {planet2.Name}!";
            }
            else 
            {
                planet2.Spend(planet2.Budget / 2);
                planet2.Profit(planet1.Budget / 2);
                var sumOfForcesCostsOfLoosing = planet1.Army.Sum(s => s.Cost);
                var sumOfweaponsPriceOfLoosing = planet1.Weapons.Sum(s => s.Price);
                planet2.Profit(sumOfweaponsPriceOfLoosing);
                planet2.Profit(sumOfForcesCostsOfLoosing);
                planets.RemoveItem(planet1.Name);
                return $"{planet2.Name} destructed {planet1.Name}!";
            }
        }
        public string ForcesReport()
        {
            var sortedPlanets = planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name);

            var sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in sortedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }

        

        
    }
}
