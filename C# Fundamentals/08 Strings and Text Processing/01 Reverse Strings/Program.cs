using System;

namespace _01_Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string reversedStr = string.Empty;

            while (input != "end")
            {
                for (int i = input.Length - 1; i >= 0 ; i--)
                {
                    reversedStr += input[i];
                }
                Console.WriteLine($"{input} = {reversedStr}");
                reversedStr = string.Empty;
                input = Console.ReadLine();
            }
        }
    }
}
