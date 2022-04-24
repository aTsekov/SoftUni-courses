using System;
using System.Linq;

namespace E02_2X2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Logic to create the matrix and to add it's elements
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sizeRow = size[0];
            int sizeCol = size[1];

            char[,] matrix = new char[sizeRow, sizeCol];

            for (int row = 0; row < sizeRow; row++)
            {
                char [] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < sizeCol; col++)
                {
                    matrix[row,col] = input[col];
                }

            }

            //--------------------------
            // Logic to find the count of 2x2 squares of equal chars.

            int squaresCount = 0;
            char topLeftElement = ' ';
            char bottomLeftElement = ' ';
            char topRightElement = ' ';
            char bottomRightElement = ' ';

            for (int row = 0;row < sizeRow - 1; row++)
            {
                for (int col = 0;col < sizeCol - 1; col++)
                {
                    topLeftElement = matrix[row,col];
                    topRightElement = matrix[row,col +1];
                    bottomLeftElement = matrix[row +1,col];
                    bottomRightElement = matrix[row +1,col +1];

                    if (topLeftElement == topRightElement && topLeftElement == bottomLeftElement && topLeftElement == bottomRightElement)
                    {
                        squaresCount++;
                    }
                }
            }
            Console.WriteLine(squaresCount);



        }
    }
}
