using System;
using System.Linq;

namespace Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] forestMatrix = new string[n, n];

            // Fill the matrix
            FillForest(forestMatrix);

            string input = string.Empty;
            int blackTruffle = 0;
            int summerTruffle = 0;
            int whiteTruffle = 0;
            int eatenTruffles = 0;

            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = info[0];
                int row = int.Parse(info[1]);
                int col = int.Parse(info[2]);

                if (command == "Collect")
                {
                    if (forestMatrix[row, col] != "-")
                    {
                        if (forestMatrix[row, col] == "B")
                        {
                            blackTruffle++;
                            forestMatrix[row, col] = "-";
                        }
                        else if (forestMatrix[row, col] == "S")
                        {
                            summerTruffle++;
                            forestMatrix[row, col] = "-";
                        }
                        else if (forestMatrix[row, col] == "W")
                        {
                            whiteTruffle++;
                            forestMatrix[row, col] = "-";
                        }


                    }

                }
                else if (command == "Wild_Boar")
                {
                    string direction = info[3];
                    if (direction == "up")
                    {
                        
                        if (forestMatrix[row,col] != "-")
                        {
                            forestMatrix[row, col] = "-";
                            eatenTruffles++;
                        }
                        for (int i = row; i <= 0; i -=2 )
                        {
                            int k = col;
                            
                                if (forestMatrix[i,k] != "-")
                                {
                                    eatenTruffles++;
                                    forestMatrix[i, k] = "-";
                                }
                            
                        }
                    }
                    else if (direction == "down")
                    {
                        if (forestMatrix[row, col] != "-")
                        {
                            forestMatrix[row, col] = "-";
                            eatenTruffles++;
                        }
                        for (int i = row; i > forestMatrix.GetLength(0); i += 2)
                        {
                            int k = col;

                            if (forestMatrix[i, k] != "-")
                            {
                                eatenTruffles++;
                                forestMatrix[i, k] = "-";
                            }

                        }
                    }
                    else if (direction == "left")
                    {
                        if (forestMatrix[row, col] != "-")
                        {
                            forestMatrix[row, col] = "-";
                            eatenTruffles++;
                        }
                        
                        for (int i = 0; i < n; i += 2)
                        {
                            int j = row;
                            if (forestMatrix[j, i] != "-")
                            {
                                eatenTruffles++;
                                forestMatrix[j, i] = "-";
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        if (forestMatrix[row, col] != "-")
                        {
                            forestMatrix[row, col] = "-";
                            eatenTruffles++;
                        }

                        for (int i = col; i < forestMatrix.GetLength(1); i += 2)
                        {
                            int j = row;
                            if (forestMatrix[j, i] != "-")
                            {
                                eatenTruffles++;
                                forestMatrix[j, i] = "-";

                            }
                        }
                    }


                }

            }
            Console.WriteLine($"Peter manages to harvest {blackTruffle} black, {summerTruffle} summer, and {whiteTruffle} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTruffles} truffles.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(forestMatrix[row,col]+ " ");
                }
                Console.WriteLine();
            }

        }

        

        private static void FillForest(string[,] forestMatrix)
        {
            for (int row = 0; row < forestMatrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ');
                for (int col = 0; col < forestMatrix.GetLength(1); col++)
                {
                    forestMatrix[row, col] = input[col];
                }
            }
        }
    }
}
