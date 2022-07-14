namespace Raiding.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Druid : BaseHero
    {
        private int powerDruid = 80;
        public Druid(string name)
            : base(name)
        {
        }

        public override int Power
        {
            get { return powerDruid; }
            protected set { powerDruid = value; }
        }
        public override string CastAbility()
        {

            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";

        }

    }
}
