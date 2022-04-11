using System;
using System.Collections.Generic;
using System.Linq;

namespace E03_Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            
            
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)       
            {
                int[] arrInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int command = arrInput[0];
                if (command == 1)
                {
                    stack.Push(arrInput[1]);
                }
                else if (command == 2)
                {
                    stack.Pop();
                }
                else if (command == 3)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    int maxValue = stack.Max();
                    Console.WriteLine(maxValue);
                }
                else if (command == 4)
                {

                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    int minValue = stack.Min();
                    Console.WriteLine(minValue);
                }

            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
