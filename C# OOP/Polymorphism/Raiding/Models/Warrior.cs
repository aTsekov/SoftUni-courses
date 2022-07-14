namespace Raiding.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Warrior : BaseHero
    {
        private int powerWarrior = 100;
        public Warrior(string name) 
            : base(name)
        {
        }
        public override int Power
        {
            get
            {
                return powerWarrior;
            }
            protected set
            {
                powerWarrior = value;
            }
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
