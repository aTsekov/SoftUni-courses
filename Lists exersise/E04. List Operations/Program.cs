using System;
using System.Collections.Generic;
using System.Linq;

namespace E04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string comand = "";

            while (comand != "End")
            {
                comand = Console.ReadLine();
                string[] token = comand.Split(" ");
                string cmd = token[0];             
                
                if (cmd == "End")
                {
                    break;
                }
                else if (cmd == "Add")
                {
                    int addNum = int.Parse(token[1]);
                    numbers.Add(addNum);
                }
                else if (cmd == "Insert")
                {
                    int element = int.Parse(token[1]);
                    int index = int.Parse(token[2]);
                    if (!IsIndexValid(numbers, index))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(index, element);
                }
                else if (cmd == "Remove")
                {
                    int indexToRemove = int.Parse(token[1]);
                    if (!IsIndexValid(numbers, indexToRemove))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(indexToRemove);
                }
                else if (cmd == "Shift")
                {
                    string leftOrRight = token[1];
                    if (leftOrRight == "left")
                    {
                        int moveIndex = int.Parse(token[2]);
                        ShiftLeft(numbers, moveIndex);
                    }
                    else if (leftOrRight == "right")
                    {
                        int moveIndex = int.Parse(token[2]);
                        ShiftRight(numbers, moveIndex);
                    }
                }
            }
            Console.WriteLine(String.Join(" ", numbers));



        } 
        static void ShiftLeft(List<int> number, int moveIndex)
        {
            int realPerformedCount = moveIndex % number.Count;
            for (int i = 0; i < realPerformedCount; i++)
            {
                int firstElement = number.First();
                number.Remove(firstElement);
                number.Add(firstElement);
                
            }
        }
        static void ShiftRight(List<int> number, int moveIndex)
        {
            int realPerformedCount = moveIndex % number.Count;
            for (int i = 0; i < realPerformedCount; i++)
            {
                int lastElement = number.Last();
                number.RemoveAt(number.Count - 1);
                number.Insert(0, lastElement);
                
            }
        }
        static bool IsIndexValid(List<int> numbers, int Index)
        {
            return Index >= 0 && Index < numbers.Count;
        }


    }
}
