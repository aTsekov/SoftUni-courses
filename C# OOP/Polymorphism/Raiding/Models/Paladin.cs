namespace Raiding.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Paladin : BaseHero
    {
        private int powerPaladin = 100;
        public Paladin(string name) 
            : base(name)
        {
        }
        public override int Power
        {
            get { return powerPaladin; }
            protected set { powerPaladin = value; }
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
