using System;

namespace _01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal boughtFood = decimal.Parse(Console.ReadLine());
            decimal boughtHay = decimal.Parse(Console.ReadLine());
            decimal boughtCover = decimal.Parse(Console.ReadLine());
            decimal guineaWeight = decimal.Parse(Console.ReadLine());
                 int dayCounter = 0;
            decimal foodInGrams = boughtFood * 1000;
            decimal hayInGrams = boughtHay * 1000;
            decimal coverInGrams = boughtCover * 1000;
            decimal guineaInGrams = guineaWeight * 1000;


            for (int day = 1; day <= 30; day++)
            {
                foodInGrams -= 300;
               dayCounter ++;

                if (day % 2 == 0)
                {
                    hayInGrams -= foodInGrams * 0.05m;
                }
                if (dayCounter == 3)
                {
                    coverInGrams -= guineaInGrams / 3;
                    dayCounter = 0;
                }
                if (foodInGrams <= 0 || boughtHay <= 0 || coverInGrams <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }

            }
            if (foodInGrams > 0 || boughtHay> 0 || coverInGrams > 0)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodInGrams / 1000:f2}, Hay: {hayInGrams / 1000:f2}, Cover: {coverInGrams / 1000:f2}.");
            }
                


        }
    }
}
