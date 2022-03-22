using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] demonsNames = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            SortedDictionary<string, DemonInfo> demonsInfo = new SortedDictionary<string, DemonInfo>();

            string healthPattern = @"[^\+\-\*\/\.\d\s]";
            string damagePattern = @"\+*\-*\d\.*\d*";
            string damageSymbolsPattern = @"[\*|\/]";

            foreach (string demon in demonsNames)
            {
                MatchCollection healthMatch = Regex.Matches(demon, healthPattern);
                demonsInfo.Add(demon, new DemonInfo());
                int health = 0;

                foreach (Match match in healthMatch)
                {
                    foreach (char symbol in match.Value)
                    {
                        health += symbol;
                    }
                }

                demonsInfo[demon].Health = health;

                MatchCollection damageMatch = Regex.Matches(demon, damagePattern);
                MatchCollection damageSymbols = Regex.Matches(demon, damageSymbolsPattern);
                double damage = 0;

                foreach (Match num in damageMatch)
                {
                    damage += double.Parse(num.Value);
                }

                if (damageSymbols.Count > 0)
                {
                    foreach (Match symbol in damageSymbols)
                    {
                        if (symbol.Value == "/")
                        {
                            damage /= 2;
                        }
                        else if (symbol.Value == "*")
                        {
                            damage *= 2;
                        }
                    }
                }

                demonsInfo[demon].Damage = damage;
            }

            foreach (var pair in demonsInfo)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value.Health} health, {pair.Value.Damage:f2} damage");
            }
        }
    }

    public class DemonInfo
    {
        public int Health { get; set; }

        public double Damage { get; set; }
    }
}
