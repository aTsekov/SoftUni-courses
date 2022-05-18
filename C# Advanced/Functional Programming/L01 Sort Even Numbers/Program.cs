using System;
using System.Linq;

namespace L01_Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var newList = line.Split(", ").Select(int.Parse).Where( x => x % 2 == 0).OrderBy(x => x);

            Console.WriteLine(String.Join(", ", newList));

        }
    }
}
