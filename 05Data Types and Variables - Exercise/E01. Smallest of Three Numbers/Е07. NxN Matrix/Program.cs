using System;

namespace Е07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Matrix(n);

            

        }

        static void Matrix(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int k = 1; k <= n; k++)
                {
                    Console.Write($"{n} ");
                }
                Console.WriteLine();
            }

        }
    }
}
