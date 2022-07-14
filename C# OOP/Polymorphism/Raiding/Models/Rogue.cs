namespace Raiding.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rogue : BaseHero
    {
        private int powerRogue = 80;
        public Rogue(string name)
            : base(name)
        {
        }

        public override int Power
        {
            get {  return powerRogue; }
            protected set { powerRogue = value; }
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
