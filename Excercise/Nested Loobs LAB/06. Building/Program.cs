using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floor = int.Parse(Console.ReadLine());
            int apparments = int.Parse(Console.ReadLine());

            for (int currentFloor = floor; currentFloor >= 1; currentFloor--)
            {
                for (int appNum = 0; appNum < apparments; appNum++)
                {
                    if (currentFloor == floor)
                    {
                        Console.Write($"L{currentFloor}{appNum} ");
                        continue;
                    }

                    if (currentFloor % 2 == 0)
                    {

                        Console.Write($"O{currentFloor}{appNum} ");
                    }

                    else if (currentFloor % 2 != 0)
                    {
                        Console.Write($"A{currentFloor}{appNum} ");

                    }

                }
                Console.WriteLine();
            }

            



        }
    }
}
