using System;
using System.Collections.Generic;

namespace _3rd_Problem
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Dictionary<string, List<string>> meals = new Dictionary<string, List<string>>();
            //Dictionary<string, string> dislikedMeals = new Dictionary<string, string>();
            string input;
            int dislikedMealsCount = 0;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commandArgs = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                string guest = commandArgs[1];
                string meal = commandArgs[2];
                if (command == "Like")
                {
                    if (!meals.ContainsKey(guest))
                    {
                        meals.Add(guest, new List<string>() { meal });
                    }
                    else if (meals.ContainsKey(guest) && !meals[guest].Contains(meal))
                    {
                        meals[guest].Add(meal);
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (command == "Dislike")
                {
                    dislikedMealsCount++;
                    if (!meals.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                        dislikedMealsCount --;

                    }
                    else if (!meals[guest].Contains(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        dislikedMealsCount--;
                    }
                    else
                    {
                        meals[guest].Remove(meal);
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                    }
                }

            }
            foreach (var kvp in meals)
            {
                string guestLiked = kvp.Key;
                List<string> liked = kvp.Value;
                Console.WriteLine($"{guestLiked}: {string.Join(", ", liked)}");

                
            }
            Console.WriteLine($"Unliked meals: {dislikedMealsCount}");

        }
    }
}
