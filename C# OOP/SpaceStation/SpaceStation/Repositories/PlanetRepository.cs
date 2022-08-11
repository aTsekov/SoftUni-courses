namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;
        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => models;

        public void Add(IPlanet model)
        {
            models.Add(model);
        }
        public bool Remove(IPlanet model)
        {
            bool check = models.Remove(model);

            return check;
        }
        public IPlanet FindByName(string name)
        {
            if (models.Any(a => a.Name == name))
            {
                var astr = models.FirstOrDefault(a => a.Name == name);
                return astr;
            }
            return null;
        }

        
    }
}
