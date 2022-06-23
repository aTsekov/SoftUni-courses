using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ingridientsInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] freshnessInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            const int dippingSauce = 150;
            const int greenSalad = 250;
            const int cholocateCake = 300;
            const int lobster = 400;

            int dippingSauceCounter = 0;
            int greenSaladCounter = 0;
            int cholocateCakeCounter = 0;
            int lobsterCounter = 0;

            Queue<int> ingridients = new Queue<int>(ingridientsInput);
            Stack<int> freshness = new Stack<int>(freshnessInput);

            while (true)
            {
                if (ingridients.Count == 0 || freshness.Count == 0)
                {
                    break;
                }
                if (ingridients.Any(i => i == 0))
                {
                    List<int> newIngredients = ingridients.Where(i => i != 0).ToList();
                    Queue<int> temp = new Queue<int>(newIngredients);
                    ingridients = temp;
                    continue;
                }
                int currentIngridient = ingridients.Peek();
                int currentFreshnnes = freshness.Peek();

                int currentDish = currentIngridient * currentFreshnnes;



                if (currentDish == dippingSauce)
                {
                    dippingSauceCounter++;
                    ingridients.Dequeue();
                    freshness.Pop();
                }
                else if (currentDish == greenSalad)
                {
                    greenSaladCounter++;
                    ingridients.Dequeue();
                    freshness.Pop();
                }
                else if (currentDish == cholocateCake)
                {
                    cholocateCakeCounter++;
                    ingridients.Dequeue();
                    freshness.Pop();
                }
                else if (currentDish == lobster)
                {
                    lobsterCounter++;
                    ingridients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    currentIngridient += 5;
                    ingridients.Dequeue();
                    ingridients.Enqueue(currentIngridient);
                }

            }


            if (dippingSauceCounter > 0 && greenSaladCounter > 0 && cholocateCakeCounter > 0 && lobsterCounter > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingridients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingridients.Sum()}");
            }
            SortedDictionary<string, int> dishes = new SortedDictionary<string, int>(); //Sroting is also True

            if (dippingSauceCounter > 0)
            {
                dishes.Add("Dipping sauce", dippingSauceCounter);
            }
            if (greenSaladCounter > 0)
            {
                dishes.Add("Green salad", greenSaladCounter);
            }
            if (cholocateCakeCounter > 0)
            {
                dishes.Add("Chocolate cake", cholocateCakeCounter);
            }
            if (lobsterCounter > 0)
            {
                dishes.Add("Lobster", lobsterCounter);
            }


            foreach (var item in dishes)
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }


        }
    }
}
