using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> citizens = new List<IBuyer>();
            List<IBuyer> rebel = new List<IBuyer>();


            for (int i = 0; i < n; i++)
            {
                string[] buyersInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (buyersInput.Length == 4) // Citizen
                {
                    string name = buyersInput[0];
                    IBuyer Curr = new Citizen(name);
                    citizens.Add(Curr);

                }
                else
                {
                    string name = buyersInput[0];
                    IBuyer Curr = new Rebel(name);
                    rebel.Add(Curr);
                }
            }
            string buyer;
            while ((buyer = Console.ReadLine()) != "End")
            {
                
                if (rebel.Any(a => a.Name == buyer))
                {
                    IBuyer reb = rebel.FirstOrDefault(a => a.Name == buyer);
                    reb.BuyFood();
                }
                if (citizens.Any(a => a.Name == buyer))
                {
                    IBuyer cit = citizens.FirstOrDefault(a => a.Name == buyer);
                    cit.BuyFood();
                }
            }
            int food = citizens.Sum(s => s.Food) + rebel.Sum(s => s.Food);
            Console.WriteLine(food);
        }
    }
}
