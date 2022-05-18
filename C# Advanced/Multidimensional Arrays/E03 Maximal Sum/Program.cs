using System;
using System.Linq;

namespace E03_Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Logic to create the matrix and to add it's elements
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sizeRow = size[0];
            int sizeCol = size[1];

            int[,] matrix = new int[sizeRow, sizeCol];

            for (int row = 0; row < sizeRow; row++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < sizeCol; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            //--------------------
            int greatestSum = 0;
            int currentSum = 0;
            int rowStartIndex = 0;
            int colStartIndex = 0;

            for (int row = 0; row < sizeRow -2; row++)
            {
                
                for (int col = 0; col < sizeCol - 2; col++)
                {
                    int topLeftElm = matrix[row, col]; 
                    currentSum = topLeftElm + matrix[row, col + 1] + matrix[row, col+2]
                        + matrix[row +1, col] + matrix[row +1,col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > greatestSum)
                    {
                        greatestSum = currentSum;
                        rowStartIndex = row; // take the index of the row of the Matrix wth the greatest sum
                        colStartIndex = col; //take the index of the column of the Matrix wth the greatest sum
                    }
                }
            }

            Console.WriteLine($"Sum = {greatestSum}");



            for (int row = rowStartIndex; row <= rowStartIndex + 2; row++) // we are itterating within the sub-matrix. 
            {
                for (int col = colStartIndex; col <= colStartIndex + 2; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }

             /// 1 5 6
             /// 4 7 9
             /// 7 2 8
             /// We are itterating from the first row until the first row + 2 and we do the same for the columns and then this way we print the sub-matrix that is in the bigger matrix. 

        }
    }
}
