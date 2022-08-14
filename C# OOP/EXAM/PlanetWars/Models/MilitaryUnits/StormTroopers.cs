namespace PlanetWars.Models
{
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StormTroopers : MilitaryUnit, IMilitaryUnit
    {
        public StormTroopers() : base(2.5)
        {
        }
    }
}
