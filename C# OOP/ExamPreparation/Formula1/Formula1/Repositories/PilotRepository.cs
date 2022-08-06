namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> models;
        public IReadOnlyCollection<IPilot> Models => models;
        public PilotRepository()
        {
            models = new List<IPilot>();
        }
        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public bool Remove(IPilot model)
        {
            if (models.Any(p => p.FullName == model.FullName))
            {
                models.Remove(model);
                return true;
            }
            return false;
        }
        public IPilot FindByName(string name)
        {
            if (models.Any( p => p.FullName == name))
            {
                return models.FirstOrDefault( p => p.FullName == name);
            }
            return null;
        }

        
    }
}
