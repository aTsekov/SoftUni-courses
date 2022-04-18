using System;
using System.Linq;

namespace L01_Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ")
                .Select(int.Parse).ToArray();

            //Първо Ред, после колони
            int[,] matrix = new int[size[0],size[1]];

            for (int row =  0; row < matrix.GetLength(0); row++)
            {
                int [] currentRow = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = currentRow[col];
                }

            }
            Console.WriteLine(size[0]);
            Console.WriteLine(size[1]);

            int sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }
    }
}
