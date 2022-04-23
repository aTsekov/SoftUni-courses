using System;

namespace L07_Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long rows = int.Parse(Console.ReadLine());
            long currntLenght = 1;
            long [][] triangle = new long[rows][];

            for (int i = 0; i < rows; i++)
            {
                triangle[i] = new long[currntLenght];
                triangle[i][0] = 1;
                triangle[i][currntLenght - 1] = 1;

                if (currntLenght > 2)
                {
                    for (int j = 1; j < currntLenght -1; j++)
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }

                }
                currntLenght++;
            }

            foreach (long[] row in triangle)
            {
                Console.WriteLine(String.Join(' ', row));
            }
        }
    }
}
