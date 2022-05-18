using System;
using System.Linq;

namespace _02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            int index1 = int.Parse(comand[1]);
            int index2 = int.Parse(comand[2]);

            while (comand[0] != "end")
            {
                
                
                if (comand[0] == "swap")
                {
                    index1 = int.Parse(comand[1]);
                    index2 = int.Parse(comand[2]);
                    int firstNumToMove = input[index1];
                    int secondNumToMove = input[index2];
                    input[index1] = secondNumToMove;    
                    input[index2] = firstNumToMove;

                }
                else if (comand[0] == "multiply")
                {
                    index1 = int.Parse(comand[1]);
                    index2 = int.Parse(comand[2]);
                    int firstNumToMultiply = input[index1];
                    int secondNumToMultiply = input[index2];
                    int result = firstNumToMultiply * secondNumToMultiply;
                    input[index1] = result;

                }
                else if (comand[0] == "decrease")
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = input[i] - 1;
                    }
                }
                comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            }
            Console.WriteLine(string.Join(", ", input));
        }
    }
}
