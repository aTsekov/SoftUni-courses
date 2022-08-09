namespace NavalVessels.Repositories
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> models;
        public IReadOnlyCollection<IVessel> Models => models;
        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }

        public void Add(IVessel model)
        {
            models.Add(model);
        }
        public bool Remove(IVessel model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);

                return true;

            }
            return false;
        }

        public IVessel FindByName(string name)
        {
            if (models.Any(p => p.Name == name))
            {
                return models.FirstOrDefault(p => p.Name == name);
            }
            return null;
        }

        
    }
}
