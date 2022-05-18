using System;
using System.Linq;

namespace L04_Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbWithVat =Console.ReadLine().Split(", ").Select(double.Parse).Select(x => x* 1.2).ToArray();

            foreach (var num  in numbWithVat)
            {
                Console.WriteLine($"{num:F2}");
            }
        }
    }
}
