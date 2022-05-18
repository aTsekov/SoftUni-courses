using System;

namespace _01_The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] commandArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandArgs[0];
                if (commandType == "Move")
                {
                    int numOfLetters = int.Parse(commandArgs[1]);
                    string substring = message.Substring(0, numOfLetters);
                    message = message.Remove(0, numOfLetters);
                    message = message + substring;
                }
                else if (commandType == "Insert")
                {
                    int insertIndex = int.Parse(commandArgs[1]);
                    string insertChar = commandArgs[2];
                    message = message.Insert(insertIndex, insertChar.ToString());
                }
                else if (commandType == "ChangeAll")
                {
                    // "ChangeAll {substring} {replacement}"
                    string stringToReplace = commandArgs[1];
                    string replacement = commandArgs[2];
                    message = message.Replace(stringToReplace, replacement);

                }

            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
