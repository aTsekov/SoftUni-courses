using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int [] divNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] allNumbers = Enumerable.Range(1, n).ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var num in divNumbers)
            {
                predicates.Add(x => x % num == 0);
            }

            foreach (var currNume  in allNumbers)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(currNume))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    Console.Write(currNume + " ");
                }
            }
        }
    }
}
