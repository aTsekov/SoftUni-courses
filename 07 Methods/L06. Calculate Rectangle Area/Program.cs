using System;

namespace L06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            
            double result = Area(width, height);
            Console.WriteLine(result);

        }
        static double Area (double width, double height)
        {
            return width * height;
        }
    }
}
