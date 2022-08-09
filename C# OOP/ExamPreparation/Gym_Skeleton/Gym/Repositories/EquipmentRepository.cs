namespace Gym.Repositories
{
    using Gym.Models.Equipment.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EquipmentRepository : IRepsitory<IEquipment>
    {
        private readonly List<IEquipment> models;
        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
            
        }

        
        public IReadOnlyCollection<IEquipment> Models => models;

        public void Add(IEquipment eqipment)
        {
            models.Add(eqipment);
        }
        public bool Remove(IEquipment equipment)
        {
            return models.Remove(equipment);
        }
        public IEquipment FindByType(string equipmentType)
        {
            foreach (var eq in models)
            {
                if (eq.GetType().Name == equipmentType)
                {
                    return eq;
                }
            }
            return null;
        }

    }
}
