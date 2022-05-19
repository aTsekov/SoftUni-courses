using System;
using System.Linq;

namespace E06_Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte rows = byte.Parse(Console.ReadLine());

            double[][] jaggedArr = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArr[i] = Console.ReadLine() // пълним всеки ред с нов масив по стандартния начин. На ред i  четем от конзолата малки масив и го слагаме в големия. 
                    .Split(' ')
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int row = 0; row < jaggedArr.Length-1; row++)
            {
                
               double [] rowOne = jaggedArr[row];
               double [] rowTwo = jaggedArr[row +1];
                if (rowOne.Length == rowTwo.Length)
                {
                    jaggedArr[row] = rowOne.Select(e => e * 2).ToArray();
                    jaggedArr[row +1] = rowTwo.Select(e => e * 2).ToArray();

                }
                else
                {
                    jaggedArr[row] = rowOne.Select(e => e / 2).ToArray();
                    jaggedArr[row + 1] = rowTwo.Select(e => e / 2).ToArray();
                }

               
            }

            string commandInput = string.Empty;
            while ((commandInput = Console.ReadLine()) != "End")
            {
                string[] arr = commandInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray(); 
                string command = arr[0];
                int row = int.Parse(arr[1]);
                int column = int.Parse(arr[2]);
                int value = int.Parse(arr[3]);
                if (command == "Add")
                {
                    if (row < 0 || row >= rows - 1 || column < 0 || column >= jaggedArr[row].Length)
                    {

                            continue;
                    }
                    else
                    {
                        jaggedArr[row][column] = jaggedArr[row][column] + value;
                    }

                }
                else if (command == "Subtract")
                {
                    if (row < 0 || row >= rows - 1 || column < 0 || column >= jaggedArr[row].Length)
                    {

                        continue;
                    }
                    else
                    {
                        jaggedArr[row][column] = jaggedArr[row][column] - value;
                    }
                }

            }

            foreach (double[] el in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", el));
            }
        }
    }
}
