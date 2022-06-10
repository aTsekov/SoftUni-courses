using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethod
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse (Console.ReadLine());
               list.Add(input); 
            }

            int[] indices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var swap = new Swap<int>(list);
            swap.SwapMethod(list,indices[0],indices[1]);
            Console.WriteLine(swap);
        }
    }
}
