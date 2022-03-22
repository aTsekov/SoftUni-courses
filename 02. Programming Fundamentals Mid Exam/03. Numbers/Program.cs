using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            double average = (double)numbers.Average();
            List<int> result = new List<int>();
            int counter = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    result.Add(numbers[i]);                   
                }
                
            }
            if (result.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            result.Sort();
                result.Reverse();

            for (int i = 0; i < result.Count; i++)
            {
                
                if(i < 5)
                {
                    Console.Write($"{result [i]} " );
                }
            }
                
            







        }
    }
}
