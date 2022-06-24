using System;
using System.Linq;

namespace Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] jaggedArr = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArr[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            int myTokens = 0;
            int oponentTokens = 0;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] arguments = command.Split(' ');
                if (arguments[0] == "Find")
                {
                    int row = int.Parse(arguments[1]);
                    int col = int.Parse(arguments[2]);
                    if (row < 0 || row > rows - 1 || col < 0 || col >= jaggedArr[row].Length)
                    {
                        continue;
                    }
                    else if (jaggedArr[row][col] == "T")
                    {
                        myTokens++;
                        jaggedArr[row][col] = "-";
                    }
                }
                else if (arguments[0] == "Opponent")
                {
                    int row = int.Parse(arguments[1]);
                    int col = int.Parse(arguments[2]);
                    string direction = arguments[3];
                    if (row < 0 || row > rows - 1 || col < 0 || col >= jaggedArr[row].Length)
                    {
                        continue;
                    }
                    else if (jaggedArr[row][col] == "T") //|| jaggedArr[row][col] == "-"
                    {
                        if (jaggedArr[row][col] == "T")
                        {
                            oponentTokens++;
                            jaggedArr[row][col] = "-";


                            if (direction == "up")
                            {
                                if (row == 0)
                                {
                                    continue;
                                }
                                for (int i = row; i > 0; i--)
                                {
                                    if (jaggedArr[i - 1][col] == "T")
                                    {
                                        oponentTokens++;
                                        jaggedArr[i - 1][col] = "-";
                                    }
                                }
                            }
                            else if (direction == "down")
                            {
                                if (row == rows)
                                {
                                    continue;
                                }
                                for (int i = row; i < 0; i++)
                                {
                                    if (jaggedArr[i + 1][col] == "T")
                                    {
                                        oponentTokens++;
                                        jaggedArr[i + 1][col] = "-";
                                    }
                                }
                            }
                            else if (direction == "left")
                            {
                                if (col == 0)
                                {
                                    continue;
                                }
                                for (int i = col; i > 0; i--)
                                {
                                    if (jaggedArr[row][i - 1] == "T")
                                    {
                                        oponentTokens++;
                                        jaggedArr[row][i - 1] = "-";
                                    }
                                }
                            }
                            else if (direction == "right")
                            {
                                if (col == jaggedArr[row].Length)
                                {
                                    continue;
                                }
                                for (int i = col; i < 0; i++)
                                {
                                    if (jaggedArr[row][i + 1] == "T")
                                    {
                                        oponentTokens++;
                                        jaggedArr[row][i + 1] = "-";
                                    }
                                }
                            }
                        }


                    }
                }

            }
            foreach (string[] el in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", el));
            }
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {oponentTokens}");
        }
    }
}
