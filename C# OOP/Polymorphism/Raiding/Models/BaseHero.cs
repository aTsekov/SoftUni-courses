namespace Raiding.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
            
        }
        public string Name { get; private set; }
        public virtual int Power { get; protected set; }
        public virtual string CastAbility()
        {
            if (GetType().Name == "Druid" || GetType().Name == "Paladin")
            {
                return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
            }
            else if (GetType().Name == "Rogue" || GetType().Name == "Warrior")
            {
                return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
            }
            else
            {
                throw new Exception("Invalid hero!");
            }
        }
    }
}
