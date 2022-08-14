namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Models.Weapons.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NuclearWeapon : Weapon, IWeapon
    {
        public NuclearWeapon(int destructionLevel) : base(destructionLevel, 15)
        {
        }
    }
}
