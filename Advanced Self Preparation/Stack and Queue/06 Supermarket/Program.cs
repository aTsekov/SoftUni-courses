using System;
using System.Collections.Generic;

namespace _06_Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input;
            Queue<string> names = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "End")
                {
                    
                    if (input == "Paid")
                    {
                        
                        Console.WriteLine(String.Join("\n",names));
                        names.Clear();
                        continue;
                    }
                    names.Enqueue(input);
                }
            }
            Console.WriteLine($"{names.Count} people remaining.");

        }
    }
}
