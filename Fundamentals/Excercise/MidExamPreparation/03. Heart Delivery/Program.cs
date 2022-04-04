using System;
using System.Linq;

namespace P03.Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;

            int houseCount = neighborhood.Length;
            int cupidPosition = 0;

            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] jumpCmd = input.Split(" ");
                int jumpDistance = int.Parse(jumpCmd[1]);
                cupidPosition += jumpDistance;

                if (cupidPosition >= neighborhood.Length)
                {
                    cupidPosition = 0;
                }


                if (neighborhood[cupidPosition] > 0)
                {
                    neighborhood[cupidPosition] -= 2;
                    if (neighborhood[cupidPosition] == 0)
                    {
                        Console.WriteLine($"Place {cupidPosition} has Valentine's day.");
                        houseCount--;
                    }
                }
                else
                {
                    Console.WriteLine($"Place {cupidPosition} already had Valentine's day.");
                }

                if (neighborhood.Sum() == 0)
                {
                    Console.WriteLine($"Cupid's last position was {cupidPosition}.");
                    Console.WriteLine("Mission was successful.");
                    return;
                }

            }

            Console.WriteLine($"Cupid's last position was {cupidPosition}.");
            Console.WriteLine($"Cupid has failed {houseCount} places.");
        }
    }
}
