using System;
using System.Collections.Generic;
using System.Linq;

namespace E05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int [] bombInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int bombNum = bombInfo[0];
            int power = Math.Abs(bombInfo[1]);

            // Обхождам целия масив и търся дали ще намеря елемент равен на числото на бомбата
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNum)
                {
                    // Търся началната точка от къде да започна да трия
                    int start = i - power;

                    // Ако началната точка е извън пределите на индекса т.е. под нулевия индекс му казвам да започва от нулевия
                    if (start < 0)
                    {
                        start = 0;
                    }

                    // Търся крайната точка до къде да трия
                    int finish = i + power + 1;

                    // Ако крайния индекс за триене е по-голям от броя елементи, то тогава края му давам да бъде равен на number.count защото иначе Exeption
                    if (finish > numbers.Count)
                    {
                        finish = numbers.Count;
                    }

                    // След като имам начална и крайна точка въртя ги в цикъл и ги трия
                    for (int j = start; j < finish; j++)
                    {
                        numbers.RemoveAt(start);
                    }
                    i--;
                }
            }

            Console.WriteLine(numbers.Sum());


        }
    }
}
