namespace Raiding.Engine
{
    using Raiding.Factory;
    using Raiding.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {

        //private readonly BaseHero druid;
        //private readonly BaseHero paladin;
        //private readonly BaseHero rogue;
        //private readonly BaseHero warrior;

        //public Engine(BaseHero druid, BaseHero paladin, BaseHero rogue, BaseHero warrior)
        //{
        //    this.druid = druid;
        //    this.paladin = paladin;
        //    this.rogue = rogue;
        //    this.warrior = warrior;
        //}
        public Engine()
        {

        }
        void Start()
        {
            int n = int.Parse(Console.ReadLine());
            int combinedPower = 0;
            for (int i = 0; i < n; i++)
            {
                HeroFactory hf = new HeroFactory();
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                hf.CreateHero(heroType, heroName);
                combinedPower += hf.HelpPower;

            }
            int bossPower = int.Parse(Console.ReadLine());


            if (bossPower < combinedPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
