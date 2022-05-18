using System;

namespace L03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string intput = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());  
            int b = int.Parse(Console.ReadLine());

            if (intput == "add")
            {
                add(a, b);
            }
            else if (intput == "substract")
            {
                substract(a, b);
            }
            else if (intput == "multiply")
            {
                multiply(a, b);
            }
            else if (intput == "divide")
            {
                divide(a, b);
            }
            



        }

        static void add (int a, int b)
        {
            Console.WriteLine(a + b);
        }
        static void substract(int a, int b)
        {
            Console.WriteLine(a - b);
        }
        static void multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }
        static void divide(int a, int b)
        {
            Console.WriteLine(a / b);
        }
    }
}
