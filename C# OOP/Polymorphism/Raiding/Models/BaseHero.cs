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
            
                throw new Exception("Invalid hero!");
            
        }
    }
}
