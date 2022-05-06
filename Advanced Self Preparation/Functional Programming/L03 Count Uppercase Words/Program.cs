using System;
using System.Linq;

namespace L03_Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var upperLetterWords = words.Where(word => char.IsUpper(word[0]));
            foreach (var word  in upperLetterWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
