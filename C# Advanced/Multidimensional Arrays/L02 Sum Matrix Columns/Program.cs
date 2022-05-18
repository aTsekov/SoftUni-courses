using System;
using System.Linq;

namespace L02_Sum_Matrix_Columns
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
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)// за всеки ред - колона по колона пълним матрицата
                {
                    matrix[row, col] = currentRow[col];
                }

            }

            //   3,4
            //   1 2 3 4
            //   5 6 7 8 
            //   9 8 7 6
            // тук сумираме колона по колона  - (1+5+9); (2+6+8) и т.н. и принтираме сумата на всяка колона.

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);

            }
        }
    }
}
