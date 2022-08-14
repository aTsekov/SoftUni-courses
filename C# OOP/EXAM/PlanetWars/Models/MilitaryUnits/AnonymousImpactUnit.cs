namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnonymousImpactUnit : MilitaryUnit, IMilitaryUnit
    {
        public AnonymousImpactUnit() : base(30)
        {
        }
    }
}
