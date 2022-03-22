using System;
using System.Linq;

namespace E01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int num1 = int.Parse(Console.ReadLine());
           int num2 = int.Parse(Console.ReadLine());
           int num3 = int.Parse(Console.ReadLine());
           PrintMallest(num1,num2, num3);
        }

        static void PrintMallest(int num1, int num2,int num3)
        {


            int smallestNum = Math.Min(Math.Min (num1,num2),num3);
            Console.WriteLine(smallestNum);

        }
    }
}
