using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> test = new List<string>();
            test.Add("Pesho");
            test.Add("Gosho");
            test.Add("Maria");
            test.Add("Ganka");
            var myStack = new StackOfStrings();
            Console.WriteLine(myStack.IsEmpty());
            myStack.AddRange(test);
        }
    }
}
