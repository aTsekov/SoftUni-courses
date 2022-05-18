using System;
using System.Collections.Generic;
using System.Linq;

namespace E07_Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPums = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < numberOfPums; i++)
            {
                int[] PumpInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(PumpInfo);
            }
            int startIndex = 0;
            while (true)
            {
                bool isValidPump = true;

                int truckFuelAmount = 0;
                foreach (int[] item in queue)
                {

                    int litters = item[0];
                    truckFuelAmount += litters;
                    int distance = item[1];
                    if (truckFuelAmount - distance < 0)
                    {
                        startIndex += 1;
                        int[] currentPum = queue.Dequeue();
                        queue.Enqueue(currentPum);
                        isValidPump = false;
                        break;
                    }
                    truckFuelAmount -= distance;
                }
                if (isValidPump)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}
