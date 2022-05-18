using System;
using System.Collections.Generic;
using System.Linq;

namespace L07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string command = Console.ReadLine();
            bool hasChanges = false;
            
            

            while (command != "end")
            {
                string[] token = command.Split(" ");
                if (token[0] == "Add")
                {
                    int numToAdd = int.Parse(token[1]);
                    numbers.Add(numToAdd);
                    hasChanges = true;

                }
                else if (token[0] == "Remove")
                {
                    int numToRemove = int.Parse(token[1]);
                    numbers.Remove(numToRemove);
                    hasChanges = true;
                }
                else if (token[0] == "RemoveAt")
                {
                    int numToRemoveAt = int.Parse(token[1]);
                    numbers.RemoveAt(numToRemoveAt);
                    hasChanges = true;
                }
                else if (token[0] == "Insert")
                {
                    int numToInserst = int.Parse(token[1]);
                    int numOnIndex = int.Parse(token[2]);
                    numbers.Insert(numOnIndex, numToInserst);
                    hasChanges = true;
                }

                else if (token[0] == "Contains")
                {
                    int numToAdd = int.Parse(token[1]);
                    if (numbers.Contains(numToAdd))
                    {
                        Console.WriteLine("Yes"); ;
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }                  
                }
                else if (token[0] == "PrintEven")
                {
                    
                    List<int> evenNumber = numbers.FindAll(x => x % 2 == 0);
                    Console.WriteLine(string.Join(" ", evenNumber));
                }
                else if (token[0] == "PrintOdd")
                {

                    List <int> oddNumber = numbers.FindAll(x => x % 2 != 0);
                    Console.WriteLine(string.Join(" ", oddNumber));
                }
                else if (token[0] == "GetSum")
                {
                    int sum = numbers.Sum();                    
                    Console.WriteLine(string.Join(" ", sum));
                }
                else if (token[0] == "Filter")
                {
                    string condition = token[1];
                    int numberForComparison = int.Parse(token[2]);
                    List<int> result = GetFilteredNums(numbers, condition, numberForComparison);
                    Console.WriteLine(string.Join(" ", result));
                }




                command = Console.ReadLine();

            }
            if (hasChanges)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            
        }
        static List<int> GetFilteredNums (List<int> allNums, string condition, int NumberForComparison)
        {

            if (condition == "<")
            {
                List<int> result = allNums.FindAll(x => x <NumberForComparison);
                return result;
            }
            else if (condition == ">")
            {
                List<int> result = allNums.FindAll(x => x > NumberForComparison);
                return result;
            }
            else if (condition == "<=")
            {
                List<int> result = allNums.FindAll(x => x <= NumberForComparison);
                return result;
            }
            else if (condition == ">=")
            {
                List<int> result = allNums.FindAll(x => x >= NumberForComparison);
                return result;
            }
            else
            {
                return allNums;
            }

        }
    }
}
