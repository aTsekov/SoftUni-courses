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
    }
}
