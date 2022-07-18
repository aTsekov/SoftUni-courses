namespace Raiding
{
    using Raiding.Factory;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int combinedPower = 0;
            int bossPower = 0;
            List<HeroFactory> listOfHeros = new List<HeroFactory>();

            for (int i = 0; i < n; i++)
            {
                try
                {
                    HeroFactory hf = new HeroFactory();
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();
                    hf.CreateHero(heroType, heroName);
                    listOfHeros.Add(hf);
                    combinedPower += hf.HelpPower;
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }


            }





            bossPower = int.Parse(Console.ReadLine());

            foreach (var item in listOfHeros)
            {
                var liss = item.HelpAbility;
                foreach (var hero in liss)
                {
                    Console.WriteLine(hero.CastAbility());
                } 
            }
            if (bossPower <= combinedPower)
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
