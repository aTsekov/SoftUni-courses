using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> stack = new Stack<string>(input .Split(" ",StringSplitOptions.RemoveEmptyEntries).Reverse());
            // правим нов стак и му подаваме входа и го обръщаме наобратно, защото иначе ще трябва да смятаме първо последните цифри, което ще даде грешен резултат. трябв ада смятаме 2 +5 = 10 + 10 = 17 - 2 =15-1=14
            {
                // 2 + 5 + 10 - 2 - 1
                int operand1 = int.Parse(stack.Pop()); // искарваме от стака число, знак и число. 
                string opr = stack.Pop();
                int operand2 = int.Parse(stack.Pop());

                if (opr == "+")
                {
                    stack.Push((operand1 + operand2).ToString());
                }
                else if (opr == "-")
                {
                    stack.Push((operand1 - operand2).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
