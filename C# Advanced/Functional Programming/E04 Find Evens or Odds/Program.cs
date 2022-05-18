using System;
using System.Collections.Generic;
using System.Linq;

namespace E04_Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate <int> isEvenOrOdd = num => num % 2 == 0;

            int [] range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int firstNum = range[0];
            int secondNum = range[1];

            List<int> nums = new List<int>();

            for (int i = firstNum; i <= secondNum; i++)
            {
                nums.Add(i);
            }

            string evenOdd = Console.ReadLine();

            if (evenOdd == "even")
            {
                Console.WriteLine(string.Join(" ", nums.Where(x =>isEvenOrOdd(x))));
            }
            else if (evenOdd == "odd")
            {
                Console.WriteLine(string.Join(" ", nums.Where(x => !isEvenOrOdd(x))));
            }


        }
    }
}
