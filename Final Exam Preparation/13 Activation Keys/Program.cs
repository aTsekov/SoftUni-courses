using System;

namespace _13_Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string [] commandArgs = input.Split(">>>");

                string command = commandArgs[0];
                if (command == "Contains")
                {
                    string subStr = commandArgs[1];
                    if (rawActivationKey.Contains(subStr))
                    {
                        Console.WriteLine($"{rawActivationKey} contains {subStr}");

                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string toUpperOrLower = commandArgs[1];
                    int startindex = int.Parse(commandArgs[2]);
                    int endindex = int.Parse(commandArgs[3]);
                    if (toUpperOrLower == "Upper")
                    {
                        string subString = rawActivationKey.Substring(startindex, endindex - startindex).ToUpper();
                        rawActivationKey = rawActivationKey.Remove(startindex, endindex - startindex);
                        rawActivationKey = rawActivationKey.Insert(startindex, subString);
                        Console.WriteLine(rawActivationKey);


                    }
                    else if (toUpperOrLower == "Lower")
                    {
                        string subString = rawActivationKey.Substring(startindex, endindex - startindex).ToLower();
                        rawActivationKey = rawActivationKey.Remove(startindex, endindex - startindex);
                        rawActivationKey = rawActivationKey.Insert(startindex, subString);
                        Console.WriteLine(rawActivationKey);
                    }
                }
                else if (command == "Slice")
                {
                    int startindex = int.Parse(commandArgs[1]);
                    int endindex = int.Parse(commandArgs[2]);
                    rawActivationKey = rawActivationKey.Remove(startindex,endindex - startindex);
                    Console.WriteLine(rawActivationKey);
                }

            }
            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}
