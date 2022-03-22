using System;
using System.Linq;

namespace E02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            PrintVowels(input);



        }
        static void  PrintVowels(string input)
        {
            int counter = 0;
            char[] vowels = new char[] {'a','e', 'o', 'i','u' };

            foreach (char ch in input.ToLower())
            {
                if(vowels.Contains(ch))
                {
                    counter++;
                }
            }


            
            Console.WriteLine($"{counter}");



        }
    }
}
