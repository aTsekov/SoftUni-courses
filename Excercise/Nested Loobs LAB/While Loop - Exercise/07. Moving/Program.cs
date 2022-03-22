using System;

namespace _07._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            double wide = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double space = wide * lenght * height;
            string sumBoxSpace = "";
            double sumBox = 0;
            double boxCounter = 0;

            while (boxCounter <= space)
            {

                sumBoxSpace = Console.ReadLine();

                if (sumBoxSpace == "Done")
                {
                    Console.WriteLine($"{space - boxCounter} Cubic meters left.");
                    return;
                }

                sumBox = double.Parse(sumBoxSpace);


                boxCounter += sumBox;

                


            }



            Console.WriteLine($"No more free space! You need {boxCounter - space} Cubic meters more.");

        }
    }
}
