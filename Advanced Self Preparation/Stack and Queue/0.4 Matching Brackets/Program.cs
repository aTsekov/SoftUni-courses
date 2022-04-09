using System;
using System.Collections.Generic;

namespace _0._4_Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            Stack<int> stack = new Stack<int>();

            // ако срещнем '(' сложи индекса му в стака. Ако срещнем ')' - искарай последния елемент от стака - това ще е отварящата скоба или началото на израза. Дължината на събстринга е от текущата итерация i  - стартовия индекс +1. 

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);

                }
                else if (input[i] == ')')
                {
                   int start = stack.Pop();
                    Console.WriteLine(input.Substring(start, i - start +1));
                }
            }
            
        }
    }
}
