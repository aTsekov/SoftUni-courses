using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string expression = Console.ReadLine();

            Stack<char> openParentheses = new Stack<char>();
            bool isTrue = true;
            foreach (char ch in expression)
            {
                if (ch =='('|| ch == '[' || ch == '{')
                {
                    openParentheses.Push(ch);
                }
                else
                {
                    if (!openParentheses.Any())
                    {
                        isTrue = false;
                    }
                    char currentOpenParentheses = openParentheses.Pop();
                    bool isRoundBalanced = currentOpenParentheses == '(' && ch == ')';
                    bool isCurlyBalanced = currentOpenParentheses == '{' && ch == '}';
                    bool isSquareBalanced = currentOpenParentheses == '[' && ch == ']';
                    if (isRoundBalanced == false && isCurlyBalanced == false && isSquareBalanced == false)
                    {
                        isTrue = false;
                        break;
                    }
                    
                }
            }
            if (isTrue)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
