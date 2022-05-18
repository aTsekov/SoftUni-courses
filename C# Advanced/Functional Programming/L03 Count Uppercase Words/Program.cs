using System;
using System.Collections.Generic;
using System.Linq;

namespace L03_Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> upperLetterWords = words.Where(word => char.IsUpper(word[0])).ToList();
            foreach (var word  in upperLetterWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
