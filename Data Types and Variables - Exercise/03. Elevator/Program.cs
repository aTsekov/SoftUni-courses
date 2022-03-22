using System;

namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short people = short.Parse(Console.ReadLine());
            short capacity = short.Parse(Console.ReadLine()); 

            double courses = Math.Ceiling ((double)people / capacity);
            Console.WriteLine(courses);

        }
    }
}
