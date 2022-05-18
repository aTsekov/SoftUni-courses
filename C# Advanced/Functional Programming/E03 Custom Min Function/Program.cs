using System;
using System.Linq;

namespace E03_Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func < int[], int> getMinNum = input =>
            {
                int minValue = int.MaxValue;

                foreach (var number in input)
                {
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }
                return minValue;
            };

            Console.WriteLine(getMinNum(input));
        }
    }
}
