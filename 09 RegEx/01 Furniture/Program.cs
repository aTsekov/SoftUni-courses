using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01_Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)\!(?<quantity>\d+)";
            decimal sum = 0;
            List<string> furnitureBought = new List<string>();


            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);
                

                if (match.Success)
                {
                    string furnitureName = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    furnitureBought.Add(furnitureName);
                    sum += price* quantity;
                }

                

            }
            Print(furnitureBought, sum);

        }
        static void Print(List<string> furnitures, decimal moneySpent)
        {
            Console.WriteLine("Bought furniture:");

            foreach (string furnitureName in furnitures)
            {
                Console.WriteLine(furnitureName);
            }

            Console.WriteLine($"Total money spend: {moneySpent:f2}");
        }
    }
}
