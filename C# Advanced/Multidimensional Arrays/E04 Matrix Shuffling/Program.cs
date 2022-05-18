using System;
using System.Linq;

namespace E04_Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Logic to create the matrix and to add it's elements
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sizeRow = size[0];
            int sizeCol = size[1];

            string[,] matrix = new string[sizeRow, sizeCol];

            for (int row = 0; row < sizeRow; row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < sizeCol; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] arr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (arr[0] == "swap" && arr.Length == 5 && int.Parse(arr[1])<= matrix.GetLength(0) && int.Parse(arr[2]) <= matrix.GetLength(1) &&
                    int.Parse(arr[3]) <= matrix.GetLength(0) && int.Parse(arr[4]) <= matrix.GetLength(1))
                {
                    
                        string elementToSwap = matrix[int.Parse(arr[1]),int.Parse(arr[2])];
                        string newPlaceforElement = matrix[int.Parse(arr[3]), int.Parse(arr[4])];
                        matrix[int.Parse(arr[3]), int.Parse(arr[4])] = elementToSwap;
                        matrix[int.Parse(arr[1]), int.Parse(arr[2])] = newPlaceforElement;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write($"{matrix[row,col]} ");
                        }
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                  
            }
        }
    }
}
