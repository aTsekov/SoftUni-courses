namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;
        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => models;

        public void Add(IAstronaut model)
        {
            models.Add(model);
        }
        public bool Remove(IAstronaut model)
        {

            bool check = models.Remove(model);

            return check;
        }
        public IAstronaut FindByName(string name)
        {
            if (models.Any( a=> a.Name == name))
            {
                var astr = models.FirstOrDefault( a => a.Name == name);
                return astr;
            }
            return null;
           
        }

       
    }
}
