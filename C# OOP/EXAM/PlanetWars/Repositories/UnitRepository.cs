namespace PlanetWars.Repositories
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {

        private List<IMilitaryUnit> models; // SHOULD I CHANGE THIS TO HASH SET????
        public UnitRepository()
        {
            models = new List<IMilitaryUnit>(); 

        }
        public IReadOnlyCollection<IMilitaryUnit> Models => models;
        public IMilitaryUnit FindByName(string name)
        {
            if (models.Any(a => a.GetType().Name == name))
            {
                var astr = models.FirstOrDefault(a => a.GetType().Name == name);
                return astr;
            }
            return null;
        }
        public void AddItem(IMilitaryUnit model)
        {
            models.Add(model);
        }

        

        public bool RemoveItem(string name)
        {
            var unit = models.FirstOrDefault(w => w.GetType().Name == name);
            bool check = models.Remove(unit);

            return check;
        }
    }
}
