 using System;
using System.Linq;

namespace L06_Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int  rows = int.Parse(Console.ReadLine()); // въвеждаме колко реда ще има назъбения масив(на всеки ред ще има по един масив)
            int [][]jaggedArr = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArr[i]= Console.ReadLine() // пълним всеки ред с нов масив по стандартния начин. На ред i  четем от конзолата малки масив и го слагаме в големия. 
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            }

            string[] tokens = Console.ReadLine().Split(' ');
            
            while (tokens[0] != "END")
            {
                int row = int.Parse(tokens[1]);
                int column = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row < 0 || row >= rows -1 || column < 0 || column >= jaggedArr[row].Length)
                {

                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (tokens[0] == "Add")
                    {
                        jaggedArr[row][column] += value;

                    }
                    else if (tokens[0] == "Subtract")
                    {
                        jaggedArr[row][column] -= value;
                    }

                }

                tokens = Console.ReadLine().Split(' ');
            }

            foreach (int[] row in jaggedArr)
            {
                Console.WriteLine(String.Join(' ', row));
            }

        }
    }
}
