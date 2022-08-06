namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => this.models;

        public void Add(IRace model)
        {
            models.Add(model);
        }
        public bool Remove(IRace model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);

                return true;

            }
            return false;
        }
        public IRace FindByName(string name)
        {
            if (models.Any(p => p.RaceName == name))
            {
                return models.FirstOrDefault(p => p.RaceName == name);
            }
            return null;
        }

        
    }
}
