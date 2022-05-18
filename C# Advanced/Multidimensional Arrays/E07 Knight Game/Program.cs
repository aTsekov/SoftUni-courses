using System;

namespace E07_Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n,n];

            for (int row = 0; row < n; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowValues[col];
                }

            }
            int counter = 0;

            while (true)
            {

                int maxAttackedKnights = 0;
                int maxAttackedKnightsRow = -1;
                int maxAttackedKnightsCol = -1;

                for (int row = 0; row < n; row++)
                {
                    

                    for (int col = 0; col < n; col++)
                    {
                        char ch = matrix[row, col];
                        if (ch == 'K')
                        {
                            int currentAttackedKnights = GetCountAttackedKnights(matrix,row,col);
                            if (currentAttackedKnights > maxAttackedKnights)
                            {
                                maxAttackedKnights = currentAttackedKnights;// Test Commit
                                maxAttackedKnightsRow = row;
                                maxAttackedKnightsCol = col;
                            }
                        }
                    }

                }
                if (maxAttackedKnights == 0)
                {
                    break;
                }
                matrix[maxAttackedKnightsRow, maxAttackedKnightsCol] = '0';
                counter ++;

            }
            Console.WriteLine(counter);


        }
        static int GetCountAttackedKnights(char[,] matrix, int row, int col)
        {
            int counter = 0;
            int n = matrix.GetLength(0);
            //up
            if (row - 2>= 0 && col - 1 >= 0 && matrix[ row - 2, col -1] == 'K')
            {
                counter++;
            }
            if (row - 2 >= 0 && col + 1 < n && matrix[row - 2, col + 1] == 'K')
            {
                counter++;
            }
            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == 'K')
            {
                counter++;
            }
            if (row - 1 >= 0 && col + 2 < n && matrix[row - 1, col + 2] == 'K')
            {
                counter++;
            }
            //down

            if (row + 1 < n && col -2 >= 0 && matrix[row + 1, col - 2] == 'K')////
            {
                counter++;
            }
            if (row + 1 < n && col + 2 < n && matrix[row + 1, col + 2] == 'K')
            {
                counter++;
            }
            if (row + 2 < n && col - 1 >= 0 && matrix[row + 2, col - 1] == 'K')
            {
                counter++;
            }
            if (row + 2 < n && col + 1 < n && matrix[row + 2, col + 1] == 'K')
            {
                counter++;
            }
            return counter;

        }
    }
}
