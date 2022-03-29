using System;
using System.Linq;

namespace _10_Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command;

            while ((command  = Console.ReadLine()) != "Done")
            {
                string [] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string commandType = parts[0];
                if (commandType == "TakeOdd")
                {
                    var oddChars = password.Where((character, index) => index % 2 != 0); // for each char take the index and check if it is odd.
                    password = string.Join(string.Empty, oddChars);
                    Console.WriteLine(password);

                }
                else if (commandType == "Cut")
                {
                    int index = int.Parse(parts[2]);
                    int lenght = int.Parse(parts[2]);
                    password= password.Remove(index, lenght);
                    Console.WriteLine(password);

                }
                else if (commandType == "Substitute")
                {
                    string subStr = parts[1];
                    string substitude = parts[2];
                   
                    if (password.Contains(subStr))
                    {
                        password = password.Replace(subStr, substitude);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
