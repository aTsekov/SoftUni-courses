using System;

namespace E06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Console.WriteLine(MiddleChars(word));
        }
        


        static string MiddleChars(string word)
        {
                int l = 1 - word.Length % 2; // ако стринга е aString  = 7%2= 1 - 1 = 0. 
                return word.Substring(word.Length / 2 - l, 1 + l);// 7/2 - 0, 1+0 = и двере уравнения правят 1. 
        }




        
    }
}
