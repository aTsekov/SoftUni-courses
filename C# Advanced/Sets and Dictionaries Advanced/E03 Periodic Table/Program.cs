using System;
using System.Collections.Generic;

namespace E03_Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> periodicTable = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                for (int k = 0; k < input.Length; k++)
                {
                    periodicTable.Add(input[k]);
                }

            }

            foreach (var item in periodicTable)
            {
                Console.Write($"{string.Join(' ',item)} ");
            }
        }
    }
}
