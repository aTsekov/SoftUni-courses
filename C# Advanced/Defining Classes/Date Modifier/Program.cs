using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            int days = DateModifier.CalculateDateDifferenceInDays(firstDate, secondDate);
            Console.WriteLine(days);
        }
    }
}
