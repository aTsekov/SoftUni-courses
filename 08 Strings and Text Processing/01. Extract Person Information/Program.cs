using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string info = string.Empty;


            for (int i = 0; i < n; i++)
            {
                info = Console.ReadLine();
                int indexStartName = info.IndexOf('@');
                int indexEndName = info.IndexOf('|');
                string name = info.Substring(indexStartName + 1, indexEndName - indexStartName - 1);
                int indexOfStartAge = info.IndexOf('#');
                int indexOfEndAge = info.IndexOf('*');
                string age = info.Substring(indexOfStartAge + 1, indexOfEndAge - indexOfStartAge - 1);

                Console.WriteLine($"{name} is {age} years old.");

            }
        }
    }
}
