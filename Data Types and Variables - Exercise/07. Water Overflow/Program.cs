using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int capacity = 255;

            int numberOfPours = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfPours; i++)
            {

                int pour = int.Parse(Console.ReadLine());
                capacity -= pour;

                if (capacity < 0)
                {
                    capacity += pour;
                    Console.WriteLine("Insufficient capacity!");
                }


            }
            Console.WriteLine(255 - capacity);
        }
    }
}
