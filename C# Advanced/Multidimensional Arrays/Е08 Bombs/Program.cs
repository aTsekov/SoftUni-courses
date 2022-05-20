using System;
using System.Linq;

namespace Е08_Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];


            //We fill the matrix with the following two loops
            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }

            }

            int[] coordinates = Console.ReadLine().Split(new char[] { ',', ' ' }).Select(int.Parse).ToArray();
            int rowCoordinate = 0;
            int colCoordinate = 1;

            for (int i = 0; i < coordinates.Length - 1; i++)
            {
                if (colCoordinate >= coordinates.Length)
                {
                    break;
                }
                int bombRow = coordinates[rowCoordinate];
                int bombCol = coordinates[colCoordinate];

                int bombValue = matrix[bombRow, bombCol];
                if (bombValue > 0)
                {
                    if (bombRow - 1 >= 0 && bombCol - 1 >= 0 && matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bombValue;
                    }
                    if (bombRow - 1 >= 0 && bombCol >= 0 && matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= bombValue;
                    }
                    if (bombRow - 1 >= 0 && bombCol + 1 < matrix.GetLength(1) && matrix[bombRow - 1, bombCol + 1] > 0) ///
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bombValue;
                    }
                    if (bombRow >= 0 && bombCol - 1 >= 0 && matrix[bombRow, bombCol - 1] != 0)
                    {
                        matrix[bombRow, bombCol - 1] -= bombValue;
                    }
                    if (bombRow <= matrix.GetLength(0) && bombCol + 1 < matrix.GetLength(1) && matrix[bombRow, bombCol + 1] > 0)////
                    {
                        matrix[bombRow, bombCol + 1] -= bombValue;
                    }
                    if (bombRow + 1 < matrix.GetLength(0) && bombCol - 1 >= 0 && matrix[bombRow + 1, bombCol - 1] > 0)//
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bombValue;
                    }
                    if (bombRow + 1 < matrix.GetLength(0) && bombCol < matrix.GetLength(1) && matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= bombValue;
                    }
                    if (bombRow + 1 < matrix.GetLength(0) && bombCol + 1 < matrix.GetLength(1) && matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bombValue;
                    }




                    matrix[bombRow, bombCol] = 0;
                    rowCoordinate += 2;
                    colCoordinate += 2;


                }

            }

            int sum = 0;
            int counter = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        counter++;
                    }

                }
            }
            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {

                    Console.Write($"{matrix[row, col]} ");


                }
                Console.WriteLine();
            }
        }
    }
}
