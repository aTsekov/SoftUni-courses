using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>(); // декларираме си един сортиран речник. Това подрежда по ключовете.Търсим колко пъти се среща някой ключ = в случава double са ключовете. 

            double [] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var item in input)
            {
                if (numbers.ContainsKey(item)) // проверяваме дали имаме ключ и ако го няма му добавяме стойността. 
                {
                    numbers[item]++; // ако го има ключа, добавяме 1 към стойноста, за да преброим колко пъти е рещнат ключа. 
                }
                else
                {
                    numbers.Add(item, 1); // ако го няма ключа, го добавяме и отброяваме че е срещнат веднъж до момента. 
                }

            }

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}"); // принтираме кой ключ колко пъти е срещнат
            }

        }
    }
}
