using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte kegsCount = byte.Parse(Console.ReadLine());
            decimal volume = decimal.MinValue;
            decimal totalVolume = 0;
            string biggestKeg = "";

            for (int i = kegsCount; i >= 1 ; i--)
            {
                string kegModel = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                uint height = uint.Parse(Console.ReadLine());

                volume = (decimal)height * (decimal)Math.Pow(radius, 2) * (decimal)Math.PI;
                kegsCount--;
                if (volume > totalVolume)
                {
                    totalVolume = volume;
                    biggestKeg = kegModel;
                }
            }

            Console.WriteLine(biggestKeg);




        }
    }
}
