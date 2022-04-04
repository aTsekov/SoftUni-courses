using System;

namespace ArraysLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] days = { "Invalid day!", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            if (n >= 1 && n <= 7)
            {
                Console.WriteLine(days[n]);
            }
            else
            {
                Console.WriteLine(days[0]);
            }
        }
    }
}
