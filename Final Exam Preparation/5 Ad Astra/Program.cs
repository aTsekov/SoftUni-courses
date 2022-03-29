using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02_Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\||#)(?<itemName>[A-Za-z\s]+)+\1(?<date>\d{2}/\d{2}/\d{2})\1(?<calories>[0-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]|10000)\1";
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);
            
            int totalCalories = 0;
            foreach (Match match in matches)
            {
                
                int calories = int.Parse(match.Groups["calories"].Value);
                totalCalories += calories;

                
            }

            int daysToLast = totalCalories / 2000;
            Console.WriteLine($"You have food to last you for: {daysToLast} days!");

            foreach (Match match in matches)
            {
                string food = match.Groups["itemName"].Value;
                string date = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);
                Console.WriteLine($"Item: {food}, Best before: {date}, Nutrition: {calories}");
            }
            
            
        }
       
    }
}
