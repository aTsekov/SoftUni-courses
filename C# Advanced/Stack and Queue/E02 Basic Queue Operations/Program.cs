using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] arrNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int nPush = arrInput[0];
            int sPop = arrInput[1];
            int xToSearch = arrInput[2];

            Queue<int> queue = new Queue<int>(arrNums);
            


            for (int i = 0; i < sPop; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(xToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("0");
                    return;
                }
                int minValue = queue.Min();
                Console.WriteLine(minValue);
            }
        }
    }
}
