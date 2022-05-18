using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <string> names = Console.ReadLine().Split(" ").ToList(); // Read the input names and split them by empty space

            Action<List<string>> printCollection = name => name.ForEach(name => Console.WriteLine($"Sir {name}"));

            printCollection(names);


            //This is less convinient way of doing the same. 
            //string[] names = Console.ReadLine().Split(" "); // Read the input names and split them by empty space

            //Action<string[]> printCollection = name => Console.WriteLine("Sir " + string.Join("\nSir ", name));

            //printCollection(names);
        }
    }
}
