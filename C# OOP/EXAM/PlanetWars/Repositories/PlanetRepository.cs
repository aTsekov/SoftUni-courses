namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models; // SHOULD I CHANGE THIS TO HASH SET????
        public PlanetRepository()
        {
            models = new List<IPlanet>();

        }
        public IReadOnlyCollection<IPlanet> Models => models;

        public IPlanet FindByName(string name)
        {
            
            if (models.Any(a => a.Name == name))
            {
                var astr = models.FirstOrDefault(a => a.Name == name);
                return astr;
            }
            return null;
        }
        public void AddItem(IPlanet model)
        {
            models.Add(model);
        }

       

        public bool RemoveItem(string name)
        {
            var planet = models.FirstOrDefault(w => w.GetType().Name == name);
            bool check = models.Remove(planet);

            return check;
        }
    }
}
