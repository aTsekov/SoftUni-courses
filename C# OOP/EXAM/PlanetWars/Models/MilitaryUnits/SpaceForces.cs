namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpaceForces : MilitaryUnit, IMilitaryUnit
    {
        public SpaceForces() : base(11)
        {
        }
    }
}
