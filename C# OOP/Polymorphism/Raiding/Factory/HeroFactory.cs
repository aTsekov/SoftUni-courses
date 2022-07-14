namespace Raiding.Factory
{
    using Raiding.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HeroFactory
    {
        public int HelpPower { get;private set; }
        public BaseHero CreateHero(string heroType, string heroName)
        {
            BaseHero baseHero;

            if (heroType == "Paladin")
            {
                baseHero = new Paladin(heroName);
                baseHero.CastAbility();
            }
            else if (heroType == "Druid")
            {
                baseHero = new Druid(heroName);
                baseHero.CastAbility();

            }
            else if (heroType == "Rogue")
            {
                baseHero = new Rogue(heroName);
                baseHero.CastAbility();
            }
            else if (heroType == "Warrior")
            {
                baseHero = new Warrior(heroName);
                baseHero.CastAbility();
            }
            else
            {
                throw new Exception("Invalid hero!");
            }
            HelpPower = baseHero.Power;
            return baseHero;
        }

    }
}
