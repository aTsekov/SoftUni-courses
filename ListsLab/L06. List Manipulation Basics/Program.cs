using System;
using System.Collections.Generic;
using System.Linq;

namespace L06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string command = Console.ReadLine();
            

            while (command != "end")
            {
                string[] token = command.Split(" ");

                if (token [0] == "Add")
                {
                    int numToAdd = int.Parse(token [1]);
                    numbers.Add(numToAdd);

                }
                else if (token[0] == "Remove")
                {
                    int numToRemove = int.Parse(token[1]);
                    numbers.Remove(numToRemove);
                }
                else if (token[0] == "RemoveAt")
                {
                    int numToRemoveAt = int.Parse(token[1]);
                    numbers.RemoveAt(numToRemoveAt);
                }
                else if (token[0] == "Insert")
                {
                    int numToInserst = int.Parse(token[1]);
                    int numOnIndex = int.Parse(token[2]);
                    numbers.Insert(numOnIndex,numToInserst);
                }


                

                command = Console.ReadLine();
                
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
