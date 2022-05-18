using System;
using System.Collections.Generic;
using System.Linq;

namespace L02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
           
            
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count/2; i++)
            {
                int newElement = numbers[i] +numbers[numbers.Count -1 - i ]; // numbers[i] ще взима първия индекс и всеки следващ.[numbers.Count -1 - i ] взима последния индекс. -i защото искаме на всяко завъртане да взимаме последния индекс. 
                // цикъла се върти до средния елемент. 
               
                result.Add(newElement);
            }
            if (numbers.Count % 2 != 0) // взимаме средния елемент и го блъскаме в последния индекс в листа с резултат. 
            {
                result.Add(numbers[numbers.Count / 2]);
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
