using System;
using System.Linq;

namespace E01_Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int sumFirstDiag = 0;
            int sumSecondDiag = 0;
            int counterSecondDiag = matrix.GetLength(0) -1;
            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];


                }
                int currentDigitBackwards = matrix[row,counterSecondDiag]; 
                counterSecondDiag--;
                sumSecondDiag += currentDigitBackwards;
                int currDigit = matrix[row, row];
                sumFirstDiag += currDigit;
            }
            int difference = Math.Abs(sumFirstDiag - sumSecondDiag);




            Console.WriteLine(sumFirstDiag);
            Console.WriteLine(sumSecondDiag);
            Console.WriteLine(difference);
        }
    }
}
