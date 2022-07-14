namespace Raiding
{
    using Raiding.Factory;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int combinedPower = 0;
            int bossPower = 0;

            for (int i = 0; i < n; i++)
            {
                try
                {
                    HeroFactory hf = new HeroFactory();
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();
                    hf.CreateHero(heroType, heroName);
                    combinedPower += hf.HelpPower;
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }


            }





            bossPower = int.Parse(Console.ReadLine());

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
