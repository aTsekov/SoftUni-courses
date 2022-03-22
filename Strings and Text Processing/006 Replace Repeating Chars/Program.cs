using System;
using System.Text;

namespace _006_Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder test = new StringBuilder();
            

            for (int i = 0; i < input.Length -1; i++)
            {
                char currCh = input[i];
                
                char nextCh = input[i +1];
                
                if (currCh != nextCh)
                {

                    
                    test.Append(currCh);
                }
                
            }
            test.Append(input[input.Length - 1]);
            Console.WriteLine(test);
        }
    }
}
