namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private AstronautRepository astornautRepository;
        private PlanetRepository planetRepository;
        private ICollection<IAstronaut> astronauts;
        private ICollection<IPlanet> planets;
        private int exploredPlanets = 0;
        public Controller()
        {
            this.astornautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.astronauts = new List<IAstronaut>();
            this.planets = new List<IPlanet>();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astr;
            if (type == "Biologist")
            {
                astr = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astr = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astr = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            astronauts.Add(astr);
            return $"Successfully added {type}: {astronautName}!";

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            
            foreach (var it in items)
            {
                planet.Items.Add(it);
            }
            planets.Add(planet);
            return $"Successfully added Planet: {planetName}!";
            
        }
        public string RetireAstronaut(string astronautName)
        {
            if (!astronauts.Any(a => a.Name == astronautName))
            {
                return $"Astronaut {astronautName} doesn't exists!";
            }
            var astr= astronauts.FirstOrDefault( a => a.Name == astronautName);
            astronauts.Remove(astr);
            return $"Astronaut {astronautName} was retired!";
        }
        public string ExplorePlanet(string planetName)
        {
            //The mistake is that I do not call the "Mission class" where the logic for collection the items is located. 
           var planetToExplore = planets.FirstOrDefault(p => p.Name == planetName);
            var suitableAstronauts = new List<IAstronaut>();
            var dead = new List<IAstronaut>();
            if (astronauts.Any( a => a.Oxygen > 60))
            {
                foreach (var astr in astronauts)
                {
                    if (astr.Oxygen > 60)
                    {
                        suitableAstronauts.Add(astr);
                        
                    }
                    //astr.Breath();
                    if (astr.Oxygen == 0)
                    {
                        dead.Add(astr);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            exploredPlanets++;

            return $"Planet: {planetName} was explored! Exploration finished with {dead.Count} dead astronauts!";
            
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astr in astronauts)
            {
                sb.AppendLine($"Name: {astr.Name}");
                sb.AppendLine($"Oxygen: {astr.Oxygen}");
                if (astr.Bag.Items.Count == 0)
                {
                    sb.AppendLine("none");
                }
                else
                {
                    var list = new List<string>(astr.Bag.Items);
                    sb.AppendLine($"Bag items: {string.Join(", ", list)}");
                }

            }

            return sb.ToString().TrimEnd();
            
        }

        
    }
}
