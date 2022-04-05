using System;
using System.Collections.Generic;

namespace _01_Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack <char> stack = new Stack<char>();

            foreach (var ch in text)
            {
                stack.Push(ch);
            }
            foreach (var item in stack)
            {
                Console.Write(item);
            }
        }
    }
}
