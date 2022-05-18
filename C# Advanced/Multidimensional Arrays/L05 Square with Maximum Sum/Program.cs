using System;
using System.Linq;

namespace L05_Square_with_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ")
               .Select(int.Parse).ToArray();

            //Първо Ред, после колони
            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)// за всеки ред от матрицата прочети целия ред.
            {
                int[] currentRow = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)// за всеки ред - колона по колона пълним матрицата
                {
                    matrix[row, col] = currentRow[col];
                }

            }
            int sum = int.MinValue;
            int currentLeadingNum = -1;
            int rightNum = -1;
            int leftSecondNum = -1;
            int rightSecondNum = -1;
            int currentSum = -1;
            int prime = -1;
            int secondary = -1;
            int prime1 = -1;
            int secondary1 = -1;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                {
                     currentLeadingNum = matrix[i, k];
                     rightNum = matrix[i , k+1];
                     leftSecondNum = matrix[i+1, k];
                     rightSecondNum = matrix[i+1, k+ 1];
                     currentSum = currentLeadingNum + rightNum + leftSecondNum + rightSecondNum;

                    if (sum < currentSum)
                    {
                        sum = currentSum;
                        prime = currentLeadingNum;

                        secondary = leftSecondNum;
                        prime1 = rightNum;
                        secondary1 = rightSecondNum;
                    }


                }
            }

            Console.WriteLine($"{prime} {prime1}\n{secondary} {secondary1}");
            Console.WriteLine(sum);
        }
    }
}
