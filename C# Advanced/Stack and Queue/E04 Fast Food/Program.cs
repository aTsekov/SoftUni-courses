using System;
using System.Collections.Generic;
using System.Linq;

namespace E04_Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int [] ordersArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> ordersQueue = new Queue<int>(ordersArr);

            int orderCount = ordersQueue.Count();
            int maxOrder = 0;
            
            while(ordersQueue.Any())
            {
                int currOrder = ordersQueue.Peek();
                if (maxOrder < currOrder)
                {
                    maxOrder = currOrder;
                }
                if (currOrder > foodQuantity)
                {
                    break;
                }
                foodQuantity -= ordersQueue.Dequeue();
                
            }
            Console.WriteLine(maxOrder);
            if (ordersQueue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
                
                
            }
            else 
            {

                Console.WriteLine("Orders complete");
            }
            

        }
    }
}
