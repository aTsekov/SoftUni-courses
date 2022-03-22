using System;
using System.Collections.Generic;
using System.Linq;

namespace E06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> secondHand = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int firstSum = 0;
            int secondSum = 0;
            int testCounter = 0;

            for (int i = 0; i <= firstHand.Count +1; i++) // как да направя цикъла да се върти докато някоя от колодите е равна на 0?
            {
                i = 0;
                testCounter++;
                int firstCurrHand = firstHand[i]; // намираме текущите числа във всяка поредица.
                int secondCurrHand = secondHand[i];

                if (firstCurrHand == secondCurrHand) // ако са равни, трием и двете ръце от текущата поредица. 
                {
                    firstHand.RemoveAt(i);
                    secondHand.RemoveAt(i);
                    
                }
                else if (firstHand[i] > secondHand [i]) 
                {
                    firstHand.Add(firstCurrHand);
                    firstHand.Add(secondCurrHand);
                    firstHand.RemoveAt(i);
                    secondHand.RemoveAt(i);
                    

                }
                

                else if (firstHand[i] < secondHand[i])
                {
                    secondHand.Add(secondCurrHand);
                    secondHand.Add(firstCurrHand);
                    secondHand.RemoveAt(i);
                    firstHand.RemoveAt(i);
                    


                }
                firstSum = firstHand.Sum();
                secondSum = secondHand.Sum();
                if (firstHand.Count == 0 )
                {
                    
                    
                    Console.WriteLine($"Second player wins! Sum: {secondSum}");
                    break;
                }
                else if (secondHand.Count == 0)
                {
                    
                    Console.WriteLine($"First player wins! Sum: {firstSum}");
                    break;
                }
                 
            }
        }
    }
}
