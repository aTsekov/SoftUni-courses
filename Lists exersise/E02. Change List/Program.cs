using System;
using System.Collections.Generic;
using System.Linq;

namespace E02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string comand = "";
            while (comand != "end")
            {
                comand = Console.ReadLine();
                string[] token = comand.Split(" ");
                if (comand == "end")
                {
                    break;
                }
                if (token [0] == "Delete")
                {
                    int numToDelete = int.Parse(token[1]);
                    numbers.RemoveAll(x => x == numToDelete);
                }
                else if (token[0] == "Insert")
                {
                    int element = int.Parse(token [1]);
                    int position = int.Parse(token [2]);
                    numbers.Insert(position, element);

                }


            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
