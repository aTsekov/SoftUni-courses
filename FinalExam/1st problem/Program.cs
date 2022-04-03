using System;

namespace _1st_problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string commandArgs;

            while ((commandArgs = Console.ReadLine()) != "Done")
            {
                string[] spilt = commandArgs.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = spilt[0];
                if (commandType == "Change")
                {
                    string oldChar = spilt[1];
                    string newChar = spilt[2];
                    text = text.Replace(oldChar, newChar);
                    Console.WriteLine(text);
                }
                else if (commandType == "Includes")
                {
                    string subStr = spilt[1];
                    if (text.Contains(subStr))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }

                }
                else if (commandType == "End")
                {
                    string subStr = spilt[1];
                    if (text.ToString().EndsWith(subStr))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (commandType == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (commandType == "FindIndex")
                {
                    
                    string charToFind = spilt[1];
                    int index = text.IndexOf(charToFind);
                    Console.WriteLine(index);

                }
                else if (commandType == "Cut")
                {
                    int startIndex = int.Parse(spilt[1]);
                    int count = int.Parse(spilt[2]);
                    string newString = text.Substring(startIndex, count);
                    Console.WriteLine(newString);
                }
            }
        }
    }
}
