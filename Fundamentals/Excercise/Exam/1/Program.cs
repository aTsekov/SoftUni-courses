using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {

            int percentageFat = int.Parse(Console.ReadLine());
            int percentageProteine = int.Parse(Console.ReadLine());
            int persentageCarb = int.Parse(Console.ReadLine());
            int totalCalories = int.Parse(Console.ReadLine());
            int percentageWater = int.Parse(Console.ReadLine());

            double fatGrams = ((double)percentageFat / 100) * totalCalories / 9;
            double proteinsGrams = ((double)percentageProteine / 100) * totalCalories / 4;
            double carbsGrams = ((double)persentageCarb / 100) * totalCalories / 4;

            double totalGramsFood = fatGrams + proteinsGrams + carbsGrams;
            double caloriesPerGram = totalCalories / totalGramsFood;
            double caloriesNoWater = ((double)percentageWater / 100) * caloriesPerGram;
            double test = caloriesPerGram - caloriesNoWater;




            Console.WriteLine($"{test:f4}");
            



        }
    }
}
