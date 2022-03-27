using System;
using System.Linq;

namespace _01_Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string [] commandTypes = command.Split(new string [] { ":|:" }, StringSplitOptions.RemoveEmptyEntries);

                string commType = commandTypes[0];
                if (commType == "InsertSpace")
                {
                    int index = int.Parse(commandTypes[1]);
                    message = message.Insert(index, " " );

                    
                }
                else if (commType == "Reverse")
                {
                    string subStr = commandTypes[1];
                    if (!message.Contains(subStr))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    else if (message.Contains(subStr))
                    {
                        int index = message.IndexOf(subStr);
                        message = message.Remove(index,subStr.Length);
                        char [] arr = subStr.ToCharArray();
                        Array.Reverse(arr);
                        subStr = new string(arr);
                        message = message + subStr;

                    }

                    
                }
                else if ( commType == "ChangeAll")
                {
                    string subStr = commandTypes[1];
                    string replacement = commandTypes[2];

                    message = message.Replace(subStr, replacement);

                    
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
