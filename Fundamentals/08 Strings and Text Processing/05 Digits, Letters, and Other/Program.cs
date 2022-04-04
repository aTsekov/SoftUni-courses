using System;
using System.Linq;
using System.Text;

namespace _05_Digits__Letters__and_Other
{
    internal class Program
    {
        private static object stringBuilder;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder letters = new StringBuilder();
            StringBuilder digits = new StringBuilder();
            StringBuilder chars = new StringBuilder();

            foreach (char ch in input)
            {
                if (char.IsLetter(ch))
                {
                    letters.Append(ch);
                }
                else if (char.IsDigit(ch))
                {
                    digits.Append(ch);
                }
                else
                {
                    chars.Append(ch) ;
                }
            }

            Console.WriteLine(digits.ToString());
            Console.WriteLine(letters.ToString());            
            Console.WriteLine(chars.ToString());
        }
        
    }
}
