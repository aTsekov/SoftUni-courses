using System;

namespace E08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine(($"{Facturial(num1,num2):f2}"));
        }

        static double Facturial (double num1, double num2)
        {
            for (double i = num1 - 1; i > 0; i--)
            {
                num1 *=i;

            }
            for (double i = num2 - 1; i > 0; i--)
            {
                num2 *= i;

            }
             double result =  num1 / num2;
            return result;
        }
    }
}
