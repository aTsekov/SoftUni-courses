using System;
using System.Collections.Generic;
using System.Linq;

namespace E04_Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            

            Dictionary<int,int> nums = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!nums.ContainsKey(number))
                {
                    nums.Add(number, 1);
                }
                else
                {
                    nums[number]++;
                }
               
            }
            Console.WriteLine( nums.First(x => x.Value% 2 ==0).Key);


        }
    }
}
