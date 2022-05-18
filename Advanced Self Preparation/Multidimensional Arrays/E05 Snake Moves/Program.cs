using System;
using System.Linq;

namespace E05_Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string snake = Console.ReadLine();

            char [,] matrix = new char[arr[0], arr[1]];
            bool isLeftToRight = true;
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (isLeftToRight)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++) //This is the loop to fill the matrix from left to right
                    {
                        matrix[row, col] = snake[counter++];
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                    }
                    isLeftToRight = false;
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)//This is the loop to fill the matrix from right to left
                    {
                        matrix[row, col] = snake[counter++];
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }
                    isLeftToRight = true;
                }
                
                
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }

        }
    }
}
