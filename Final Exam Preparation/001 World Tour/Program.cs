using System;
using System.Linq;

namespace _001_World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stopsStr = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Travel")
            {
                string [] cmdArgs= command.Split(':',StringSplitOptions.RemoveEmptyEntries).ToArray();

                string commandType = cmdArgs[0];

                if (commandType == "Add Stop")
                {
                    int insertIndex = int.Parse(cmdArgs[1]);
                    string insertString = cmdArgs[2];
                    stopsStr = InsertStringAtIndex(stopsStr, insertIndex, insertString);
                    Console.WriteLine(stopsStr);
                }
                else if (commandType == "Remove Stop") 
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    stopsStr = RemoveStringInRange(stopsStr, startIndex, endIndex);
                    Console.WriteLine(stopsStr);
                }
                else if (commandType == "Switch")
                {
                    string oldString  = cmdArgs[1];
                    string newString = cmdArgs[2];
                    stopsStr = ReplaceAllOccurances(stopsStr, oldString, newString);
                    Console.WriteLine(stopsStr);
                }

            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stopsStr}");



        }
        static string InsertStringAtIndex(string originalStr, int insertIndex, string insertString)
        {
            if (!IsIndexValid(originalStr,insertIndex))
            {
                return originalStr;
            }
            string modifiedStr = originalStr.Insert(insertIndex, insertString);
            return modifiedStr;
        }
        static bool IsIndexValid(string str, int index)
        {
            return index>= 0 && index< str.Length;
        }
        static string RemoveStringInRange(string originalStr, int startIndex, int endIndex) 
        {
            if (!IsIndexValid(originalStr,startIndex))
            {
                return originalStr;
            }
            if (!IsIndexValid(originalStr, endIndex))
            {
                return originalStr;
            }
            string modifiedString = originalStr.Remove(startIndex, endIndex - startIndex +1);
            return modifiedString;
        }
        static string ReplaceAllOccurances(string originalStr, string oldString, string newString)
        {
            string modifiedString = originalStr;
            
                modifiedString = originalStr.Replace(oldString, newString);
            
            return modifiedString;
        }


    }
}
