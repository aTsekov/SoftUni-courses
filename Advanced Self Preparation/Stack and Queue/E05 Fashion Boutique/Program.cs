using System;
using System.Collections.Generic;
using System.Linq;

namespace E05_Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] clothes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(clothes);

            int rackCapacity = int.Parse(Console.ReadLine());
            int CONSTRACK = rackCapacity;
            int racksCounter = 1;

            while (stack.Count != 0)
            {
                int currCloth = stack.Peek();
                if (currCloth <= rackCapacity)
                {
                    stack.Pop();
                    rackCapacity -= currCloth;
                }
                else if (currCloth > rackCapacity)
                {
                    racksCounter++;
                    
                    rackCapacity = CONSTRACK;

                }
            }
            Console.WriteLine(racksCounter);

        }
    }
}
