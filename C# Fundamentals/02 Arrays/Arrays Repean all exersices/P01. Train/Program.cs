using System;
using System.Linq;

namespace P01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numWagons = int.Parse(Console.ReadLine());
            int sum = 0;
            int[] newArr = new int[numWagons];

            for (int i = 0; i <numWagons ; i++)
            {
                int [] passengers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                newArr [i] = passengers[0];
                sum += newArr [i];
                

            }
            Console.WriteLine(String.Join(" ",newArr));
            Console.WriteLine(sum);
        }
    }
}
