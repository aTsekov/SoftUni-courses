using System;
using System.Collections.Generic;
using System.Linq;

namespace L01_Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
             double [] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Dictionary <double, int> counter = new Dictionary<double, int>();

            foreach (var number in input)
            {
                if (counter.ContainsKey(number))
                {
                    counter[number] += 1;
                }
                else
                {
                    counter[number] = 1;
                }
            }

            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
