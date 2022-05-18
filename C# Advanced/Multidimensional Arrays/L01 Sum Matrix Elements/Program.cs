using System;
using System.Linq;

namespace L01_Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ")
                .Select(int.Parse).ToArray(); // четем от конзолата колко реда и колко лолони ще има двуизмерната матрица.

            //Първо Ред, после колони
            int[,] matrix = new int[size[0],size[1]];

            for (int row =  0; row < matrix.GetLength(0); row++)
            {
                int [] currentRow = Console.ReadLine() // за всеки ред от матрицата прочети целия ред.
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = currentRow[col]; // за всеки ред - колона по колона пълним матрицата
                }

            }
            Console.WriteLine(size[0]);// отпечатваме броя на редовете
            Console.WriteLine(size[1]);// отпечатваме броя на колоните

            int sum = 0;
            foreach (var item in matrix)// минаваме през всички елементи на матрицата и ги сумираме един по един
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }
    }
}
