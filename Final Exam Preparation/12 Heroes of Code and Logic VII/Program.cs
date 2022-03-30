using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,Heros> heros = new Dictionary<string,Heros>();
            AddHeros(n, heros);


            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string heroName = commands[1];
                if (command == "CastSpell")
                {
                    
                    int neededMP = int.Parse(commands[2]);
                    string spellName = commands[3];
                    if (heros[heroName].MP >= neededMP)
                    {
                        int leftMP = heros[heroName].MP - neededMP;
                        heros[heroName].MP -= neededMP;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {leftMP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(commands[2]);
                    string attacker = commands[3];
                    heros [heroName].HP -= damage;
                    int leftHP = heros[heroName].HP;
                    if (heros[heroName].HP > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {leftHP} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heros.Remove(heroName);
                    }
                }
                else if (command == "Recharge")
                {
                    int rechargeAmount = int.Parse(commands[2]);
                    
                    if ((heros[heroName].MP + rechargeAmount) > 200)
                    {
                        int current = heros[heroName].MP;
                        int recharged = 200 - current;
                        heros[heroName].MP = 200;
                        Console.WriteLine($"{heroName} recharged for {recharged} MP!");
                    }
                    else
                    {
                        heros[heroName].MP += rechargeAmount;
                        Console.WriteLine($"{heroName} recharged for {rechargeAmount} MP!");
                    }


                }
                else if (command == "Heal")
                {
                    int healAmount = int.Parse(commands[2]);

                    if ((heros[heroName].HP + healAmount) > 100)
                    {
                        int currentMP = heros[heroName].HP;
                        int recharged = 100 - currentMP;
                        heros[heroName].HP = 100;
                        Console.WriteLine($"{heroName} healed for {recharged} HP!");
                    }
                    else
                    {
                        heros[heroName].HP += healAmount;
                        Console.WriteLine($"{heroName} healed for {healAmount} HP!");
                    }
                }

            }
            foreach (var hero in heros)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }

            
        }
        static void AddHeros ( int n, Dictionary<string, Heros> heros)
        {
            for (int i = 0; i < n; i++)
            {
                string[] herosInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = herosInfo[0];
                int HP = int.Parse(herosInfo[1]);
                int MP = int.Parse(herosInfo[2]);

                Heros hero = new Heros(name, HP, MP);
                heros[name] = hero;

            }
        }
        class Heros
        {
            public Heros(string name, int hp, int mp)
            {
                this.Name = name;
                this.HP = hp;
                this.MP = mp;
            }
            public string Name { get; set; }

            public int HP { get; set; }

            public int MP { get; set; }
        }
    }
}
