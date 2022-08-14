namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models; // SHOULD I CHANGE THIS TO HASH SET????
        public WeaponRepository()
        {
            models = new List<IWeapon>();
            
        }
        public IReadOnlyCollection<IWeapon> Models => models;

        public IWeapon FindByName(string name)
        {
            if (models.Any(a => a.GetType().Name == name))
            {
                var astr = models.FirstOrDefault(a => a.GetType().Name == name);
                return astr;
            }
            return null;
        }
        public void AddItem(IWeapon model)
        {
           models.Add(model);
        }

       

        public bool RemoveItem(string name)
        {
            var weaponToFind = models.FirstOrDefault( w => w.GetType().Name == name);
            bool check = models.Remove(weaponToFind);

            return check;
        }
    }
}
