using System;

namespace MID_EXAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flowrePrice = double.Parse(Console.ReadLine());
            double singleEggPrice = double.Parse(Console.ReadLine());
            double singleApron = double.Parse(Console.ReadLine());

            double totalPriceEggs = (singleEggPrice * 10) *students;
            //double totalPriceForAllNeededEggs = totalPriceEggsPerStudent * students;
            //double totalPriceFlowerNoDiscount = flowrePrice * students;
            double totalPriceApron = Math.Ceiling((students *1.2)) * singleApron; // да проверя дали не закръгля и 1.2? 
            int numberOfFlower = 0;
            int studCount = 0;

            for (int i = 0; i < students; i++)
            {
                studCount++;
                if (studCount == 5)
                {
                    numberOfFlower++;
                    studCount = 0;
                }
            }
            
            double totalPriceForFlower = flowrePrice* (students - numberOfFlower);

            double totalNeededBudget = totalPriceForFlower + totalPriceApron + totalPriceEggs;

            if (totalNeededBudget <= budget)
            {
                Console.WriteLine($"Items purchased for {totalNeededBudget:f2}$.");
            }
            else if (totalNeededBudget > budget)
            {
                Console.WriteLine($"{totalNeededBudget - budget:f2}$ more needed.");
            }




        }
    }
}
