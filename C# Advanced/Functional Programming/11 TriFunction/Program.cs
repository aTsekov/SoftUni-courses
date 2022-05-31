using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Console.WriteLine(names
                .First(name => name.Select(symbol => (int) symbol).Sum() >= n));

            //Print the first name > Select each symbol of that name cast it to int value of each symbol and the sum should be = n
            
        }
    }
}
