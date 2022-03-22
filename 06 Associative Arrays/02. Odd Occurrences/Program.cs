using System;
using System.Collections.Generic;

namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] words = Console.ReadLine().Split(); // правим масив, с който приемаме думите

            Dictionary<string, int> counts = new Dictionary<string, int>(); // правим си речник

            foreach (string word in words) // за всяка дума в речника
            {
                string wordInLowerCase = word.ToLower(); // правим думите в речника, да не са case sensitive, затова вс ги правим малки
                if (counts.ContainsKey(wordInLowerCase)) // ако ключа от речника съществува, към value на ключа, прибави едно, че сме го срещнали веднъж до момента
                {
                    counts[wordInLowerCase]++;

                }
                else
                {
                    counts.Add(wordInLowerCase, 1); // ако ключа не съществува, го добави към речника и добави 1, към стойността му, за да преброим, че вече е срещнат веднъж след като е добавен.
                }
            }

            foreach(var count in counts) // за всяка двойка/pair в речника
            {
                if (count.Value % 2 != 0)// ако value е нечетно, принтирай ключа
                {
                    Console.Write(count.Key + " ");

                }
            }
        }
    }
}
