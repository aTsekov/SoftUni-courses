using System;
using System.Collections.Generic;
using System.Linq;

namespace L03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> numbers2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List <int> result = new List<int>();
            int longerCount = 0;

            if (numbers1.Count> numbers2.Count) // търсим по-дългия лист
            {
                longerCount = numbers1.Count;
            }
            else if (numbers1.Count<= numbers2.Count)
            {
                longerCount = numbers2.Count;
            }

            
            // започваме да въртим цикъл за да добавяме, първо първото число, после второто. 
            for (int i = 0; i < longerCount; i++)
            {
                if (i < numbers1.Count) // ако i е по малко от дължината на първия лист, добави към резултата номера от i. тайа ще добавяме числа докато единия лист не приключи и другия ще продължава да се изпълнява за да можем да добавим последните числа от по-дългия лист към резултатния лист. 
                {
                    result.Add(numbers1[i]);                        
                }
                if (i< numbers2.Count)
                {
                    result.Add(numbers2[i]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
