namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models; 
        public FormulaOneCarRepository()
        {
            
            this.models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => this.models;

        

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }
        public bool Remove(IFormulaOneCar model)
        {
           
            if (models.Contains(model))
            {
                models.Remove(model);
                
                return true;

            }
            return false;
        }
        public IFormulaOneCar FindByName(string name)
        {

            if (models.Any(a => a.Model == name))
            {
                return models.FirstOrDefault( a => a.Model == name);
            }
            return null;
        }

        
    }
}
