using System;
using System.Collections.Generic;

namespace _15_P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary <string, TargetedCities> cities = new Dictionary<string, TargetedCities>();
            
            string targetedCities;
            while ((targetedCities = Console.ReadLine()) != "Sail")
            {
                string[] split = targetedCities.Split("||", StringSplitOptions.RemoveEmptyEntries);

                string city = split[0];
                int people = int.Parse(split[1]);
                int gold = int.Parse(split[2]);
                TargetedCities newCity = new TargetedCities(city, people, gold);
                if (cities.ContainsKey(city))
                {
                    cities[city].People += people;
                    cities[city].Gold += gold;

                }
                else
                {
                    cities.Add(city, newCity);
                }

            }
            string attackCommand;
            while ((attackCommand = Console.ReadLine()) != "End")
            {
                string[] attackSplit = attackCommand.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string attackType = attackSplit[0];

                if (attackType == "Plunder")
                {
                    string cityToAttack = attackSplit[1];
                    int peopletoKill = int.Parse(attackSplit[2]);
                    int goldToSteal = int.Parse(attackSplit[3]);
                    cities[cityToAttack].People -= peopletoKill;
                    cities[cityToAttack].Gold -= goldToSteal;
                    Console.WriteLine($"{cityToAttack} plundered! {goldToSteal} gold stolen, {peopletoKill} citizens killed.");
                    if (cities[cityToAttack].People <= 0 || cities[cityToAttack].Gold <= 0)
                    {
                        cities.Remove(cityToAttack);
                        Console.WriteLine($"{cityToAttack} has been wiped off the map!");
                    }

                }
                else if (attackType == "Prosper")
                {
                    string cityToProsper = attackSplit[1];
                    int goldToAdd = int.Parse(attackSplit[2]);
                    if (cities[cityToProsper].Gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                        continue;
                    }
                    else
                    {
                        cities[cityToProsper].Gold += goldToAdd;
                        Console.WriteLine($"{goldToAdd} gold added to the city treasury. {cityToProsper} now has {cities[cityToProsper].Gold} gold.");
                    }

                }

            }
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var element in cities)
                {
                    Console.WriteLine($"{element.Key} -> Population: {element.Value.People} citizens, Gold: {element.Value.Gold} kg");
                }

            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
        class TargetedCities
        {
            public TargetedCities(string city, int people, int gold)
            {
                this.City = city;
                this.People = people;
                this.Gold = gold;
            }
            public string City { get; set; }

            public int People { get; set; }

            public int Gold { get; set; }
        }
    }
}
