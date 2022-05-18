using System;
using System.Collections.Generic;
using System.Linq;


namespace E05_Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int>  numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            


            Func<List<int>, List<int>> add = num =>
             {
                 

                 for (int i = 0; i < numbers.Count; i++)
                 {
                     numbers[i]++;
                 }
                 return numbers;
             };
            Func<List<int>, List<int>> subtract = num =>
            {


                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i]--;
                }
                return numbers;
            };
            Func<List<int>, List<int>> multiply = num =>
            {


                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] *= 2;
                }
                return numbers;
            };
            Action<List<int>> Print = num => Console.WriteLine(String.Join(" ", numbers));
            


            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    add(numbers);
                }
                else if (command == "multiply")
                {
                    multiply(numbers);
                }
                else if (command == "subtract")
                {
                    subtract(numbers);
                }
                else if (command == "print")
                {
                    Print(numbers);
                }


            }


        }
    }
}
