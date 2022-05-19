using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            int[,] squareMatrix = FillSquareMatrix(dimensions);

            int[] coordinatesOfBomb = Console.ReadLine()
                                             .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToArray();
            for (int i = 0; i < coordinatesOfBomb.Length; i += 2)
            {
                int currentRowBomb = coordinatesOfBomb[i];
                int currentColBomb = coordinatesOfBomb[i + 1];

                if (IsValid(currentRowBomb, currentColBomb, squareMatrix) &&
                    squareMatrix[currentRowBomb, currentColBomb] > 0)
                {
                    int bombDamage = squareMatrix[currentRowBomb, currentColBomb];
                    squareMatrix = Explosion(bombDamage, currentRowBomb, currentColBomb, squareMatrix);
                }
            }

            List<int> activeCells = FindActiveCells(squareMatrix);
            Console.WriteLine($"Alive cells: {activeCells.Count}");
            Console.WriteLine($"Sum: {activeCells.Sum()}");
            PrintMatrix(squareMatrix);

        }

        private static void PrintMatrix(int[,] squareMatrix)
        {
            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    Console.Write(squareMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static List<int> FindActiveCells(int[,] squareMatrix)
        {
            List<int> activeCells = new List<int>();

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    if (squareMatrix[row, col] > 0)
                    {
                        activeCells.Add(squareMatrix[row, col]);
                    }
                }
            }

            return activeCells;
        }

        public static int[,] FillSquareMatrix(int dimensions)
        {
            int[,] squareMatrix = new int[dimensions, dimensions];

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                int[] numbersToFill = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    squareMatrix[row, col] = numbersToFill[col];//test
                }
            }

            return squareMatrix;
        }

        private static int[,] Explosion(int bombDamage, int currentRowBomb, int currentColBomb, int[,] squareMatrix)
        {
            if (IsValid(currentRowBomb - 1, currentColBomb, squareMatrix) && squareMatrix[currentRowBomb - 1, currentColBomb] > 0)
            {
                squareMatrix[currentRowBomb - 1, currentColBomb] -= bombDamage;
            }
            if (IsValid(currentRowBomb + 1, currentColBomb, squareMatrix) && squareMatrix[currentRowBomb + 1, currentColBomb] > 0)
            {
                squareMatrix[currentRowBomb + 1, currentColBomb] -= bombDamage;
            }
            if (IsValid(currentRowBomb - 1, currentColBomb - 1, squareMatrix) && squareMatrix[currentRowBomb - 1, currentColBomb - 1] > 0)
            {
                squareMatrix[currentRowBomb - 1, currentColBomb - 1] -= bombDamage;
            }
            if (IsValid(currentRowBomb - 1, currentColBomb + 1, squareMatrix) && squareMatrix[currentRowBomb - 1, currentColBomb + 1] > 0)
            {
                squareMatrix[currentRowBomb - 1, currentColBomb + 1] -= bombDamage;
            }
            if (IsValid(currentRowBomb + 1, currentColBomb - 1, squareMatrix) && squareMatrix[currentRowBomb + 1, currentColBomb - 1] > 0)
            {
                squareMatrix[currentRowBomb + 1, currentColBomb - 1] -= bombDamage;
            }
            if (IsValid(currentRowBomb + 1, currentColBomb + 1, squareMatrix) && squareMatrix[currentRowBomb + 1, currentColBomb + 1] > 0)
            {
                squareMatrix[currentRowBomb + 1, currentColBomb + 1] -= bombDamage;
            }
            if (IsValid(currentRowBomb, currentColBomb - 1, squareMatrix) && squareMatrix[currentRowBomb, currentColBomb - 1] > 0)
            {
                squareMatrix[currentRowBomb, currentColBomb - 1] -= bombDamage;
            }
            if (IsValid(currentRowBomb, currentColBomb + 1, squareMatrix) && squareMatrix[currentRowBomb, currentColBomb + 1] > 0)
            {
                squareMatrix[currentRowBomb, currentColBomb + 1] -= bombDamage;
            }

            squareMatrix[currentRowBomb, currentColBomb] -= bombDamage;

            return squareMatrix;
        }

        public static bool IsValid(int row, int col, int[,] squareMatrix)
        {
            return (row >= 0 && row < squareMatrix.GetLength(0) && col >= 0 && col < squareMatrix.GetLength(1));
        }
    }
}