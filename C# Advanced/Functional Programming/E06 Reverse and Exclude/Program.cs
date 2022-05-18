using System;
using System.Collections.Generic;
using System.Linq;

namespace E06_Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            
            int n = int.Parse(Console.ReadLine());

            numbers.Reverse();

            Action<List<int>> removeDivisible = nums =>
            {

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (nums[i] % n != 0)
                    {
                        Console.Write($"{nums[i]} ");
                    }
                }


            };

            removeDivisible(numbers);
        }
    }
}
