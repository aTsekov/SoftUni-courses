using System;

namespace _04._Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int numA = int.Parse(Console.ReadLine());
            int numB = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = numA; i <= numB; i++)
            {

                Console.Write($"{i} ");
                sum += i;
                
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");



        }
    }
}
