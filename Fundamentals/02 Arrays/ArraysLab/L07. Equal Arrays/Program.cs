using System;
using System.Linq;

namespace L07._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < array1.Length; i++)
            {
                sum += array2[i];

                if (array1[i] != array2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }
                else if (array1[i] == array2[i] && i == array2.Length-1)                               
                {
                    Console.WriteLine($"Arrays are identical. Sum: {sum}");
                }

            }
        }
    }
}
