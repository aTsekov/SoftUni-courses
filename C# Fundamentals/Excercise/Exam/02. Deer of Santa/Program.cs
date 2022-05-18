using System;

namespace _02._Deer_of_Santa
{
    class Program
    {
        static void Main(string[] args)
        {

            int DaysOff = int.Parse(Console.ReadLine());
            int totalFood = int.Parse(Console.ReadLine());
            double firstDeerFoodPerDay = double.Parse(Console.ReadLine());
            double secondDeerFoodPerDay = double.Parse(Console.ReadLine());
            double thirdDeerFoodPerDay = double.Parse(Console.ReadLine());

            double firstDeerTotal = DaysOff * firstDeerFoodPerDay;
            double secondDeerTotal = DaysOff * secondDeerFoodPerDay;
            double thirdDeerTotal = DaysOff * thirdDeerFoodPerDay;

            double totalNeededFood = firstDeerTotal + secondDeerTotal + thirdDeerTotal;

            if (totalNeededFood <= totalFood)
            {
                Console.WriteLine($"{Math.Floor(totalFood - totalNeededFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling (totalNeededFood - totalFood)} more kilos of food are needed.");
            }

        }
    }
}
