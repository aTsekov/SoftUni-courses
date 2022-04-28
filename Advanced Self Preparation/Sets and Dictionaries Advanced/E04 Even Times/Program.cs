using System;
using System.Collections.Generic;

namespace E04_Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 1;
            double numToSave = int.MinValue;

            HashSet<int> nums = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int m = int.Parse(Console.ReadLine());
                

                if (nums.Contains(m))
                {
                    counter++;
                    numToSave = m;
                }
                nums.Add(m);
            }
            Console.WriteLine(numToSave);


        }
    }
}
