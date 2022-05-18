using System;
using System.Collections.Generic;
using System.Linq;

namespace E01_Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] arrInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] arrNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int nPush = arrInput[0];
            int sPop = arrInput[1];
            int xToSearch = arrInput[2];

            Stack<int> stack = new Stack<int>(arrNums);
            //Finally an integer X, an element that you should look for in the stack. If it’s found, print "true" on the console. If it isn’t, print the smallest element currently present in the stack. If there are no elements in the sequence, print 0 on the console.

            
            for (int i = 0; i < sPop; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(xToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("0");
                    return;
                }
                int minValue = stack.Min();
                Console.WriteLine(minValue);
            }
            



        }
    }
}
