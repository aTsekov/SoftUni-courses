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
            var list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
               list.Add(input); 
            }

            int[] indices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var swap = new Swap<string>(list);
            swap.SwapMethod(list,indices[0],indices[1]);
            Console.WriteLine(swap);
        }
    }
}
