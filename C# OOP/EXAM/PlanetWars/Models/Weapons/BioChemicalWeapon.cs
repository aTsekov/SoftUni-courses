namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Models.Weapons.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BioChemicalWeapon : Weapon, IWeapon
    {
        public BioChemicalWeapon(int destructionLevel) : base(destructionLevel, 3.2)
        {
        }
    }
}
