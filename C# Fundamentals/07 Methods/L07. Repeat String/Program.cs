using System;

namespace L07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string result = RepeatString(input, n);
            Console.WriteLine(result);

        }

        static string RepeatString(string input, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                 result = result + input;
            }
            return result;
        }

    }
}
