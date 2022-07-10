using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ICreature> creatures = new List<ICreature>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string [] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 5) // HUMAN
                {
                    string birthday = tokens[4];
                    ICreature citizen= new Citizen(birthday);
                    creatures.Add(citizen);
                }
                else if (tokens[0].StartsWith('P')) // PET
                {
                    string birthday = tokens[2];
                    ICreature pet = new Pet(birthday);
                    creatures.Add(pet);
                }
            }
            
            string bdayToSearch = Console.ReadLine();
            List<ICreature> matchedBdays = new List<ICreature> ();

            foreach (var item in creatures)
            {
                int index = item.Birthday.Length - bdayToSearch.Length;
                string lastDigits = item.Birthday.Substring(index);
                if (lastDigits == bdayToSearch)
                {
                    matchedBdays.Add(item);
                }
            }
            foreach (var item in matchedBdays)
            {
                Console.WriteLine(item.Birthday);
            }

        }
    }
}
