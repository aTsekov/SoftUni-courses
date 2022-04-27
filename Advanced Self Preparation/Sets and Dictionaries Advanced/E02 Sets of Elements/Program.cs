using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] nM = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = nM[0];
            int m = nM[1];

            HashSet <int> nNums = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int nNumbers = int.Parse(Console.ReadLine());   
                nNums.Add(nNumbers);

            }

            HashSet<int> mNums = new HashSet<int>();

            for (int i = 0; i < m; i++)
            {
                int mNumbers = int.Parse(Console.ReadLine());
                mNums.Add(mNumbers);

            }

           nNums.IntersectWith(mNums);

            foreach (var item in nNums)
            {
                Console.Write($"{String.Join(" ", item)} ");
            }


        }
    }
}
