using System;

namespace E01_Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string [] names = Console.ReadLine().Split(" "); // Read the input names and split them by empty space

            Action<string []> printCollection = name => Console.WriteLine(string.Join("\n",name)); // create an action of type string [] array. printCollection is the name of the functions. name is tha lambda func. 

            printCollection(names);
            




        }
        
    }
}
