using System;
using System.Linq;

namespace The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        private static char[,] matrix;
        private static int armyRow;
        private static int armyCol;
        private static int orcsRow;
        private static int orcsCol;
        private static int energy;
        private static bool IsWinner;

        static void Main(string[] args)
        {
            energy = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            IsWinner = false;

            //Initialize Matrix
            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine()
                    .Replace(" ", "")
                    .ToCharArray();

                for (int col = 0; col < input.Length; col++)
                {
                    
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }
            // Find where the Army is


            while (matrix[armyRow, armyCol] != 'M'||  energy > 0)
            {
                if (IsWinner == true)
                {
                    matrix[armyRow, armyCol] = '-';
                    break;
                }
                if (energy <= 0)
                {
                    break;
                }
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                orcsRow = int.Parse(input[1]);
                orcsCol = int.Parse(input[2]);
                matrix[orcsRow, orcsCol] = 'O';
                Move(command);
            }
            

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write((char)matrix[i, j]);
                    
                }
                Console.WriteLine();
            }
        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
        private static void Move(string command)
        {
            if (!IsInside(armyRow, armyCol)) // if the army tries to move outside, reduce the energy.
            {
                energy -= 2;
            }
            
            if (command == "up")
            {
                matrix[armyRow, armyCol] = '-';
                armyRow--;
                if (armyRow < 0)
                {
                    armyRow= 0;
                }
            }
            else if (command == "down")
            {
                matrix[armyRow, armyCol] = '-';
                armyRow++;
                if (armyRow > matrix.GetLength(0) - 1)
                {
                    armyRow = matrix.GetLength(0) - 1;
                }
            }
            else if (command == "left")
            {
                matrix[armyRow, armyCol] = '-';
                armyCol--;
                if (armyCol < 0)
                {
                    armyCol = 0;
                }
            }
            else if (command == "right")
            {
                matrix[armyRow, armyCol] = '-';
                armyCol++;
                if (armyCol > matrix.GetLength(0) - 1)
                {
                    armyCol = matrix.GetLength(0) - 1;
                }
            }
            if (IsInside(armyRow,armyCol))
            {
                if (matrix[armyRow, armyCol] == '-' || matrix[armyRow, armyCol] == 'M') // if we move the army and they go to an empty cell
                {
                    energy--;
                }
            }
            
            if (matrix[armyRow, armyCol] == 'O') //If the army meets enemy. 
            {
                energy -= 3;
                if (energy <= 0)//If the army dies.
                {
                    matrix[armyRow, armyCol] = 'X';
                    if (energy <= 0)
                    {
                        Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                        
                    }

                }
                else
                {
                    matrix[armyRow, armyCol] = '-'; //If the army wins, the orks are removed and we place '-'.
                }
            }
            if (matrix[armyRow, armyCol] == 'M') //The army wins
            {
                IsWinner = true;
                
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {energy}");
            }
            if (energy < 0)
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

        }
    }
}