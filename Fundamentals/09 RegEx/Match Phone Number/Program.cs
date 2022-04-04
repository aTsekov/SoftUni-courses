using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359([ |-])2\1\d{3}\1\d{4}\b";

            string phones = Console.ReadLine();

            MatchCollection phoneMatches = Regex.Matches(phones, pattern);

            List<string> matches = new List<string>();

            foreach (Match match in phoneMatches)
            {
                matches.Add(match.Value.Trim());
            }
            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
