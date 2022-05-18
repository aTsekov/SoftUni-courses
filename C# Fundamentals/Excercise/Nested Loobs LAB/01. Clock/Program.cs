using System;

namespace _01._Clock
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int hours = 0; hours <= 23; hours++)
            {
                for (int mins = 0; mins <= 59; mins++)
                {
                    Console.WriteLine($"{hours}:{mins}");
                }
            }


        }
    }
}
