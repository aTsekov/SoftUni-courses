using System;
using System.Linq;

namespace L03_Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int. Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];
            int sum = 0;
            for (int row = 0; row < n; row++)
            {
                int [] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    //int currDigit = matrix[row, col];

                    //sum += currDigit;
                    
                }
            }
            for (int i = 0; i < n; i++)
            {
                int currDigit = matrix[i,i];
                sum += currDigit;
            }

            Console.WriteLine(sum);
        }
    }
}
