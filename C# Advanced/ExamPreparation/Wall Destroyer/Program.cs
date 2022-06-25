using System;
using System.Linq;

namespace Wall_Destroyer
{
    internal class Program
    {
        private static int VankoRow;
        private static int VankoCol;
        private static char[,] matrix;
        private static int n;
        private static int totalHoles = 0;
        private static int totalRods = 0;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine()
                    .Replace(" ", "")
                    .ToCharArray();

                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                    if (matrix[i, j] == 'V')
                    {
                        VankoRow = i;
                        VankoCol = j;
                        totalHoles++;
                        matrix[i, j] = '*';
                    }
                }
            }

            string command = string.Empty;
            bool electrocuted = false;

            while ((command = Console.ReadLine()) != "End")
            {
                

                if (command == "up")
                {
                    if (!IsInside(VankoRow - 1, VankoCol))
                    {
                        continue;
                    }
                    else if (matrix[VankoRow - 1, VankoCol] == '-')
                    {
                        totalHoles++;
                        matrix[VankoRow - 1, VankoCol] = '*';
                        VankoRow --;
                    }
                    else if (matrix[VankoRow - 1, VankoCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        totalRods++;
                        
                    }
                    else if (matrix[VankoRow - 1, VankoCol] == 'C')
                    {
                        matrix[VankoRow - 1, VankoCol] = 'E';
                        totalHoles++;
                        VankoRow--;
                        electrocuted = true;
                        
                    }
                    else if (matrix[VankoRow - 1, VankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{VankoRow - 1}, {VankoCol}]!");
                        VankoRow--;
                        
                    }

                }
                else if (command == "down")
                {
                    if (!IsInside(VankoRow + 1, VankoCol))
                    {
                        continue;
                    }
                    else if (matrix[VankoRow + 1, VankoCol] == '-')
                    {
                        totalHoles++;
                        matrix[VankoRow + 1, VankoCol] = '*';
                        VankoRow ++;
                    }
                    else if (matrix[VankoRow + 1, VankoCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        totalRods++;
                        
                    }
                    else if (matrix[VankoRow + 1, VankoCol] == 'C')
                    {
                        matrix[VankoRow + 1, VankoCol] = 'E';
                        totalHoles++;
                        VankoRow++;
                        electrocuted = true;
                        
                    }
                    else if (matrix[VankoRow + 1, VankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{VankoRow + 1}, {VankoCol}!");
                        VankoRow ++;
                        
                    }
                }
                else if (command == "left")
                {
                    if (!IsInside(VankoRow, VankoCol - 1))
                    {
                        continue;
                    }
                    else if (matrix[VankoRow, VankoCol - 1] == '-')
                    {
                        totalHoles++;
                        matrix[VankoRow, VankoCol - 1] = '*';
                        VankoCol --;
                    }
                    else if (matrix[VankoRow, VankoCol -1] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        totalRods++;
                        
                    }
                    else if (matrix[VankoRow, VankoCol - 1] == 'C')
                    {
                        matrix[VankoRow, VankoCol - 1] = 'E';
                        totalHoles++;
                        VankoCol--;
                        electrocuted = true;
                        
                    }
                    else if (matrix[VankoRow, VankoCol - 1] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{VankoRow}, { VankoCol - 1}]!");
                        VankoCol--;
                        
                    }
                }
                else if (command == "right")
                {
                    if (!IsInside(VankoRow, VankoCol + 1))
                    {
                        continue;
                    }
                    else if (matrix[VankoRow, VankoCol + 1] == '-')
                    {
                        totalHoles++;
                        matrix[VankoRow, VankoCol + 1] = '*';
                        VankoCol ++;
                    }
                    else if (matrix[VankoRow, VankoCol + 1] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        totalRods++;
                        
                    }
                    else if (matrix[VankoRow, VankoCol + 1] == 'C')
                    {
                        matrix[VankoRow, VankoCol + 1] = 'E';
                        totalHoles++;
                        VankoCol++;
                        electrocuted = true;
                        
                    }
                    else if (matrix[VankoRow, VankoCol + 1] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{VankoRow}, { VankoCol + 1}]!");
                        VankoCol++;
                        
                    }
                }
                if (electrocuted == true)
                {
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {totalHoles} hole(s).");
                    Print();
                    return;
                }

            }

            Console.WriteLine($"Vanko managed to make {totalHoles} hole(s) and he hit only {totalRods} rod(s).");
            matrix[VankoRow, VankoCol] = 'V';
            Print();

        }

        private static void Print()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);

                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
