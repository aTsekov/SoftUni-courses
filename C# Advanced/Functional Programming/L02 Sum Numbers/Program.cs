using System;
using System.Linq;

namespace L02_Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ").Select(MyParse);

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
        static int MyParse (string numberAsString)
        {
            int number = 0;
            foreach (var digit  in numberAsString)
            {
                number *= 10;
                number += (digit - '0');
            }
            return number;
        }
    }
}
