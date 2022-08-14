namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Models.Weapons.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpaceMissiles : Weapon, IWeapon
    {
        public SpaceMissiles(int destructionLevel) : base(destructionLevel, 8.75)
        {
        }
    }
}
