using System;
using System.Text.RegularExpressions;

namespace _2nd_Problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@+|#+)(?<color>[a-z]{3,})(@+|#+)\W*(\/+)(?<digit>\d+)(\/+)";
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match item in matches)
            {
                Console.WriteLine($"You found {item.Groups["digit"]} {item.Groups["color"]} eggs!");

            }
        }
    }
}
