using System;

namespace Pawn_Wars
{
    internal class Program
    {
        private static char[,] matrix;
        private static int whiteRow;
        private static int whiteCol;
        private static int blackRow;
        private static int blackCol;
        static void Main(string[] args)
        {

            matrix = new char[8, 8];
            FillTheMatrixAndFindThePawns();
            Move(whiteRow, whiteCol, blackRow, blackCol);
        }
        static void Move(int whiteRow, int whiteCol, int blackRow, int blackCol)
        {
            string rowCoordinates = string.Empty;
            string colCoordinates = string.Empty;
            // ****************************WHITE****************************
            for (int i = 0; i < 16; i++)
            {
                if (IsInside(whiteRow - 1, whiteCol - 1))
                {
                    if (matrix[whiteRow - 1, whiteCol - 1] == 'b') // this is the case when we move the white and find the black on the diagonal.
                    {
                        rowCoordinates = CoordinatesRow(whiteRow - 1);
                        colCoordinates = CoordinatesCol(whiteCol - 1);
                        Console.WriteLine($"Game over! White capture on {colCoordinates + rowCoordinates}.");
                        break;
                    }
                }
                if (IsInside(whiteRow - 1, whiteCol + 1))
                {
                    if (matrix[whiteRow - 1, whiteCol + 1] == 'b')
                    {
                        rowCoordinates = CoordinatesRow(whiteRow - 1);
                        colCoordinates = CoordinatesCol(whiteCol + 1);
                        Console.WriteLine($"Game over! White capture on {colCoordinates + rowCoordinates}.");
                        break;
                    }
                }
                if (IsInside(whiteRow - 1, whiteCol))
                {
                    if (matrix[whiteRow - 1, whiteCol] == '-') // this is the case when the next step is not a pawn and just a dash. 
                    {
                        matrix[whiteRow, whiteCol] = '-'; // the current place the the pawn becomes dash and the the figure moves to the next one. 
                        matrix[whiteRow - 1, whiteCol] = 'w';
                        whiteRow--;
                        if (whiteRow == 0) // the WHITE pawn reached the last row and he wins.
                        {
                            rowCoordinates = CoordinatesRow(whiteRow);
                            colCoordinates = CoordinatesCol(whiteCol);
                            Console.WriteLine($"Game over! White pawn is promoted to a queen at {colCoordinates + rowCoordinates}.");
                            break;
                        }
                    }
                }

                //if (whiteRow - 1 == 0) // the WHITE pawn reached the last row and he wins.
                //{
                //    rowCoordinates = CoordinatesRow(whiteRow - 1);
                //    colCoordinates = CoordinatesCol(whiteCol);
                //    Console.WriteLine($"Game over! White pawn is promoted to a queen at {colCoordinates + rowCoordinates}.");
                //    break;
                //}
                //****************************BLACK****************************
                if (IsInside(blackRow + 1, blackCol + 1))
                {
                    if (matrix[blackRow + 1, blackCol + 1] == 'w') // this is the case when we move the white and find the black on the diagonal.
                    {
                        rowCoordinates = CoordinatesRow(blackRow + 1);
                        colCoordinates = CoordinatesCol(blackCol + 1);
                        Console.WriteLine($"Game over! Black capture on {colCoordinates + rowCoordinates}.");
                        break;
                    }
                }
                if (IsInside(blackRow + 1, blackCol - 1))
                {
                    if (matrix[blackRow + 1, blackCol - 1] == 'w')
                    {
                        rowCoordinates = CoordinatesRow(blackRow + 1);
                        colCoordinates = CoordinatesCol(blackCol - 1);
                        Console.WriteLine($"Game over! Black capture on {colCoordinates + rowCoordinates}.");
                        break;
                    }
                }

                if (IsInside(blackRow + 1, blackCol))
                {
                    if (matrix[blackRow + 1, blackCol] == '-') // this is the case when the next step is not a pawn and just a dash. 
                    {
                        matrix[blackRow, blackCol] = '-'; // the current place the the pawn becomes dash and the the figure moves to the next one. 
                        matrix[blackRow + 1, blackCol] = 'b';
                        blackRow++;
                        if (blackRow == 7) // the BLACK pawn reached the last row and he wins.
                        {
                            rowCoordinates = CoordinatesRow(blackRow);
                            colCoordinates = CoordinatesCol(blackCol);
                            Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colCoordinates + rowCoordinates}.");
                            break;
                        }
                    }
                }

                //if (blackRow + 1 == 7) // the BLACK pawn reached the last row and he wins.
                //{
                //    rowCoordinates = CoordinatesRow(blackRow + 1);
                //    colCoordinates = CoordinatesCol(blackCol);
                //    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colCoordinates + rowCoordinates}.");
                //    break;
                //}
            }


        }

        public static void FillTheMatrixAndFindThePawns()
        {
            for (int row = 0; row < 8; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = (char)input[col];
                    if (input[col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (input[col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }
        }

        public static string CoordinatesRow(int row)
        {
            if (row == 0)
            {
                return "8";
            }
            else if (row == 1)
            {
                return "7";
            }
            else if (row == 2)
            {
                return "6";
            }
            else if (row == 3)
            {
                return "5";
            }
            else if (row == 4)
            {
                return "4";
            }
            else if (row == 5)
            {
                return "3";
            }
            else if (row == 6)
            {
                return "2";
            }
            else if (row == 7)
            {
                return "1";
            }
            else
            {
                return "-1";
            }
        }
        public static string CoordinatesCol(int col)
        {
            if (col == 0)
            {
                return "a";
            }
            else if (col == 1)
            {
                return "b";
            }
            else if (col == 2)
            {
                return "c";
            }
            else if (col == 3)
            {
                return "d";
            }
            else if (col == 4)
            {
                return "e";
            }
            else if (col == 5)
            {
                return "f";
            }
            else if (col == 6)
            {
                return "g";
            }
            else if (col == 7)
            {
                return "h";
            }
            else
            {
                return "-1";
            }
        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
