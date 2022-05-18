using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] n = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack <int> stack = new Stack <int>();

            foreach (int item in n)
            {
                stack.Push(item);
            }

            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] arguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = arguments[0].ToLower();
                if (command == "add")
                {
                    int firstNum = int.Parse(arguments[1]);
                    int secondNum = int.Parse(arguments[2]);
                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (command == "remove")
                {
                    int elementsToRemove = int.Parse(arguments[1]);
                    if (elementsToRemove < stack.Count)
                    {
                        for (int i = 0; i < elementsToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        continue;
                    }
                    

                }

            }
            int sum = 0;
            foreach (var item in stack)
            {
                sum += item;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
