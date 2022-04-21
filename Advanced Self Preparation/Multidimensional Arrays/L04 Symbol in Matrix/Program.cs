using System;
using System.Linq;

namespace L04_Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];
            int sum = 0;
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    char ch1 = input[col];
                    matrix[row, col] = ch1.ToString();
                    
                    

                }                
            }
            char ch = Console.ReadLine()[0];

            int w = matrix.GetLength(0); // width / row
            int h = matrix.GetLength(1); // height / col
            bool isFound = false;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    if (matrix[x, y] == $"{ch}")
                    {
                        Console.WriteLine($"({x}, {y})");
                        isFound = true;
                        break;
                    }
                      
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{ch} does not occur in the matrix");
            }
        }
    }
}
