namespace Raiding.Factory
{
    using Raiding.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HeroFactory
    {
        public int HelpPower { get;private set; }
        public List<BaseHero> HelpAbility { get;private set; }
        public HeroFactory()
        {
            HelpAbility = new List<BaseHero>();
        }

        public BaseHero CreateHero(string heroType, string heroName)
        {
           
            BaseHero baseHero;

            if (heroType == "Paladin")
            {
                baseHero = new Paladin(heroName);
                //Console.WriteLine (baseHero.CastAbility());
                HelpAbility.Add(baseHero);
            }
            else if (heroType == "Druid")
            {
                baseHero = new Druid(heroName);
                //Console.WriteLine(baseHero.CastAbility());
                HelpAbility.Add(baseHero);

            }
            else if (heroType == "Rogue")
            {
                baseHero = new Rogue(heroName);
                //Console.WriteLine(baseHero.CastAbility());
                HelpAbility.Add(baseHero);
            }
            else if (heroType == "Warrior")
            {
                baseHero = new Warrior(heroName);
                //Console.WriteLine (baseHero.CastAbility());
                HelpAbility.Add(baseHero);
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
