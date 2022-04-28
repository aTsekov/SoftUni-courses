using System;
using System.Collections.Generic;

namespace E05_Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();


            SortedDictionary<char, int> counts = new SortedDictionary<char, int>(); // правим си речник

            foreach (char ch in text) // за всяка дума в речника
            {
                
                if (counts.ContainsKey(ch))
                {

                    counts[ch]++;

                }
                else
                {
                    counts.Add(ch, 1);
                }
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");

            }
        }
    }
}
