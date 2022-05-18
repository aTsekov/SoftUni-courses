using System;
using System.Text.RegularExpressions;

namespace _06_Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s|^)[a-z0-9]+[a-z\d\.\-_]+\@[a-z\-]+\.([A-Za-z\-\.]+)+\b";

            string input = Console.ReadLine();

            MatchCollection match = Regex.Matches(input, pattern);

            foreach (Match m in match)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}
