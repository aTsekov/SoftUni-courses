using System;

namespace _06._Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n ; i++)
            {
                for (int k = 0; k < n ; k++)
                {
                    for (int l = 0; l <  n; l++)
                    {
                        char firstChar = (char)('a'+i);
                        char secondChar = (char)('a' + k);
                        char thirdChar = (char)('a' +l);
                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }

            }

            

        }
    }
}
