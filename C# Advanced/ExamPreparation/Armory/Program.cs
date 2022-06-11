using System;

namespace Armory
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int officerRow = 0;
            int officerCol = 0;
            int numberOfSwards = 0;
            int money = 0;

            //Filling the matrix
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }

                }
            }

            string direction = Console.ReadLine();

            while (true)
            {


                if (direction == "up")
                {
                    if (!IsInside(officerRow - 1, officerCol, matrix, n)) //if not in the armory, stop the program and start printing the results.
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {money} gold coins.");
                        matrix[officerRow, officerCol] = '-';
                        PrintMatrix(n, matrix);
                        Environment.Exit(0);
                    }
                    Move(1, 0, matrix, n, ref officerRow, ref officerCol, direction, ref numberOfSwards, ref money);

                }
                else if (direction == "down")
                {
                    if (!IsInside(officerRow + 1, officerCol, matrix, n)) //if not in the armory, stop the program and start printing the results.
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {money} gold coins.");
                        matrix[officerRow, officerCol] = '-';
                        PrintMatrix(n, matrix);
                        Environment.Exit(0);
                    }
                    Move(1, 0, matrix, n, ref officerRow, ref officerCol, direction, ref numberOfSwards, ref money);
                }
                else if (direction == "right")
                {
                    if (!IsInside(officerRow + 1, officerCol, matrix, n)) //if not in the armory, stop the program and start printing the results.
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {money} gold coins.");
                        matrix[officerRow, officerCol] = '-';
                        PrintMatrix(n, matrix);
                        Environment.Exit(0);
                    }
                    Move(0, 1, matrix, n, ref officerRow, ref officerCol, direction, ref numberOfSwards, ref money);
                }
                else if (direction == "left")
                {
                    if (!IsInside(officerRow, officerCol - 1, matrix, n)) //if not in the armory, stop the program and start printing the results.
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {money} gold coins.");
                        matrix[officerRow, officerCol] = '-';

                        PrintMatrix(n, matrix);
                        Environment.Exit(0);
                    }
                    Move(0, 1, matrix, n, ref officerRow, ref officerCol, direction, ref numberOfSwards, ref money);
                }

               


                if (money >= 65) //Pothential error
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    Console.WriteLine($"The king paid {money} gold coins.");
                    //matrix[officerRow, officerCol] = '-';
                    PrintMatrix(n, matrix);
                    Environment.Exit(0);
                }
                direction = Console.ReadLine();
                matrix[officerRow, officerCol] = '-'; //after each move, the last place of the officer becomes - because he left it.
            }


            ////////////////////////////////
            static void Move(int row, int col, char[,] matrix, int n, ref int officerRow, ref int officerCol, string direction, ref int numberOfSwards, ref int money)
            {


                if (direction == "up")
                {

                    if (IsInside(officerRow - row, officerCol, matrix, n))// the office is inside
                    {
                        if (char.IsDigit(matrix[officerRow - 1, officerCol]))
                        {
                            numberOfSwards++;
                            money += matrix[officerRow - 1, officerCol] - 48;
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow - 1, officerCol] = 'A';
                            officerRow--;
                        }
                        else if (matrix[officerRow - 1, officerCol] == 'M') // if we find mirror
                        {
                            matrix[officerRow - 1, officerCol] = '-'; // we make the mirror we just found to '-'
                            for (int romM = 0; romM < n; romM++)
                            {
                                for (int colM = 0; colM < n; colM++)
                                {
                                    if (matrix[romM, colM] == 'M')
                                    {
                                        matrix[romM, colM] = '-';
                                        officerRow = romM;
                                        officerCol = colM;
                                    }

                                }
                            }
                        }
                        else
                        {
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow - 1, officerCol] = 'A';
                            officerRow--;
                        }
                    }




                }
                else if (direction == "down")
                {
                    if (IsInside(officerRow + row, officerCol, matrix, n))// the office is inside
                    {
                        if (char.IsDigit(matrix[officerRow + 1, officerCol]))
                        {
                            numberOfSwards++;
                            money += matrix[officerRow + 1, officerCol] - 48;
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow + 1, officerCol] = 'A';
                            officerRow++;


                        }
                        else if (matrix[officerRow + 1, officerCol] == 'M') // if we find mirror
                        {
                            matrix[officerRow + 1, officerCol] = '-'; // we make the mirror we just found to '-'
                            for (int romM = 0; romM < n; romM++)
                            {
                                for (int colM = 0; colM < n; colM++)
                                {
                                    if (matrix[romM, colM] == 'M')
                                    {
                                        matrix[romM, colM] = '-';
                                        officerRow = romM;
                                        officerCol = colM;
                                    }

                                }
                            }
                        }
                        else
                        {
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow + 1, officerCol] = 'A';
                            officerRow++;
                        }

                    }

                }
                else if (direction == "right")
                {
                    if (IsInside(officerRow, officerCol + col, matrix, n))// the office is inside
                    {
                        if (char.IsDigit(matrix[officerRow, officerCol + 1]))
                        {
                            numberOfSwards++;
                            money += (matrix[officerRow, officerCol + 1]) - 48;
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow, officerCol + 1] = 'A';
                            officerCol++;
                        }
                        else if (matrix[officerRow, officerCol + 1] == 'M') // if we find mirror
                        {
                            matrix[officerRow, officerCol + 1] = '-'; // we make the mirror we just found to '-'
                            for (int romM = 0; romM < n; romM++)
                            {
                                for (int colM = 0; colM < n; colM++)
                                {
                                    if (matrix[romM, colM] == 'M')
                                    {
                                        matrix[romM, colM] = '-';
                                        officerRow = romM;
                                        officerCol = colM;
                                    }

                                }
                            }
                        }
                        else
                        {
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow, officerCol + 1] = 'A';
                            officerCol++;
                        }
                    }

                }
                else if (direction == "left")
                {
                    if (IsInside(officerRow, officerCol - col, matrix, n))// the office is inside
                    {
                        if (char.IsDigit(matrix[officerRow, officerCol - 1]))
                        {
                            numberOfSwards++;
                            money += matrix[officerRow, officerCol - 1] - 48;
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow, officerCol - 1] = 'A';
                            officerCol--;
                        }
                        else if (matrix[officerRow, officerCol - 1] == 'M') // if we find mirror
                        {
                            matrix[officerRow, officerCol - 1] = '-'; // we make the mirror we just found to '-'
                            for (int romM = 0; romM < n; romM++)
                            {
                                for (int colM = 0; colM < n; colM++)
                                {
                                    if (matrix[romM, colM] == 'M')
                                    {
                                        matrix[romM, colM] = '-';
                                        officerRow = romM;
                                        officerCol = colM;
                                    }

                                }
                            }
                        }
                        else
                        {
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow, officerCol - 1] = 'A';
                            officerCol--;
                        }
                    }


                }



            }



            static bool IsInside(int row, int col, char[,] matrix, int n)
            {
                return row >= 0 && row < matrix.GetLength(0) &&
                       col >= 0 && col < matrix.GetLength(1);
            }
        }

        private static void PrintMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);

                }
                Console.WriteLine();
            }
        }
    }
}
