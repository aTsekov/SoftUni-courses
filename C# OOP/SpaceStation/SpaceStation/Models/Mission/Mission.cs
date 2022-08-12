namespace SpaceStation.Models.Mission
{
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Mission : IMission
    {
        
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var ast in astronauts)
            {
                
                if (ast.Oxygen > 0)
                {
                    while (ast.Oxygen> 0 && planet.Items.Any())
                    {
                        var item = planet.Items.FirstOrDefault(); 
                        ast.Breath();
                        ast.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                    }
                    
                }
            }
        }
    }
}
