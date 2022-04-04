using System;
using System.Collections.Generic;
using System.Linq;

namespace _001_Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            

            Dictionary<char, int> counts = new Dictionary<char, int>(); // правим си речник

            foreach (char ch in text) // за всяка дума в речника
            {
                if (ch == ' ')
                {
                    continue;
                }
                
                if (counts.ContainsKey(ch))
                {
                    
                    counts[ch]++;

                }
                else
                {
                    counts.Add(ch, 1);
                }
            }

            

            foreach (var count in counts) // за всяка двойка/pair в речника
            {
                    Console.WriteLine($"{count.Key} -> {count.Value}");
            }
        }
    }
}
