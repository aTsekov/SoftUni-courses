using System;
using System.Numerics;

namespace Big_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger fact = 1;

            for (int i = 1; i <= n; i++)
            {
                 fact *= i;

            }
            Console.WriteLine(fact);
        }
    }
}
