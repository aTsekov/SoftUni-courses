using System;
using System.Collections.Generic;
using System.Linq;

namespace Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary <string, int> plantInfo = new Dictionary<string, int>();
            Dictionary <string, List<double>> plantRating = new Dictionary<string, List<double>> ();
            AddPlants(n, plantInfo);

            string input;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] commandArgs = input.Split(new string[] { ": ", " - " },StringSplitOptions.None);
                string command = commandArgs[0];
                string plant = commandArgs[1];

                if (command == "Rate")
                {
                    
                    double rating = double.Parse(commandArgs[2]);
                    if (!plantInfo.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        //break;
                    }
                    else if (!plantRating.ContainsKey(plant))
                    {
                        plantRating.Add(plant, new List<double> { rating });
                    }
                    else
                    {
                        plantRating[plant].Add(rating);
                    }
                    

                }
                else if (command == "Update")
                {
                    int rarity = int.Parse(commandArgs[2]);
                    if (!plantInfo.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        plantInfo[plant] = rarity;
                    }

                }
                else if (command == "Reset")
                {
                    if (!plantRating.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        plantRating[plant].Clear();
                    }
                }


            }

            PrintOutputInformation(plantInfo, plantRating);



        }
        static void AddPlants (int n, Dictionary<string, int> plantInfo)
        {
            for (int i = 0; i < n; i++)
            {
                string[] plantInput = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = plantInput[0];
                int rarity = int.Parse(plantInput[1]);
                if (!plantInfo.ContainsKey(plant))
                {
                    plantInfo.Add(plant, rarity);
                }
                else
                {
                    plantInfo[plant] = rarity;
                }
            }
        }
        static void PrintOutputInformation(Dictionary<string, int> plantInfo,
            Dictionary<string, List<double>> plantRatings)
        {
            Console.WriteLine($"Plants for the exhibition:");
            foreach (var kvp in plantInfo)
            {
                string plantName = kvp.Key;
                int rarity = kvp.Value;
                double avgRating = 0;

                if (plantRatings.ContainsKey(plantName) && plantRatings[plantName].Any())
                {
                    avgRating = plantRatings[plantName].Average();
                }

                Console.WriteLine($"- {plantName}; Rarity: {rarity}; Rating: {avgRating:f2}");
            }
        }
    }
}
