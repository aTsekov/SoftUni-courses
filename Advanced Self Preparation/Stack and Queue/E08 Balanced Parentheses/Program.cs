using System;
using System.Collections.Generic;

namespace E08_Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string expression = Console.ReadLine();

            Stack<char> openParentheses = new Stack<char>();
            foreach (char ch in expression)
            {
                if (ch =='('|| ch == '[' || ch == '{')
                {
                    openParentheses.Push(ch);
                }
                else
                {
                    char currentOpenParentheses
                }
            }
        }
    }
}
