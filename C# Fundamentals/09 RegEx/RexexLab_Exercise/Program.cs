using System;
using System.Text.RegularExpressions;

namespace RexexLab_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b([A-Z][a-z]+) ([A-Z][a-z]{2,})\b";
            
            string names = Console.ReadLine();
            MatchCollection matchedNames = Regex.Matches(names, pattern); // check the names for matches based on the pattern. 

            foreach (Match name in matchedNames)
            {
                Console.WriteLine(name.Value + " ");
            }
            Console.WriteLine();

        }
    }
}
