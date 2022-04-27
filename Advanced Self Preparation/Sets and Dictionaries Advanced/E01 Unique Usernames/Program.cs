using System;
using System.Collections.Generic;

namespace E01_Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string inputUserName = Console.ReadLine();

                usernames.Add(inputUserName);
            }

            foreach (var item in usernames)
            {
                Console.WriteLine(item);
            }

        }
    }
}
