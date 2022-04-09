using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue <int>queue = new Queue<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    queue.Enqueue(arr[i]);
                    
                    
                }
            }
            Console.WriteLine(string.Join(", ",queue));
            
        }
    }
}
