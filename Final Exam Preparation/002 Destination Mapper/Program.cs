using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _002_Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

                string input = Console.ReadLine();
                string pattern = @"(\=|\/)(?<destination>[A-Z][A-Za-z]{2,})(\1)";
                int travelPoint = 0;

                List<string> destinations = new List<string>();

                MatchCollection matches = Regex.Matches(input, pattern);

                foreach (Match currMatch in matches)
                {
                    string currDestination = currMatch.Groups["destination"].Value;

                    destinations.Add(currDestination);
                    travelPoint += currDestination.Length;
                }

                Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
                Console.WriteLine($"Travel Points: {travelPoint}");

            
        }
    }
}
    
