using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double [] waterInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            double [] flourInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Queue<double> water = new Queue<double>(waterInput);
            Stack<double> flour = new Stack<double>(flourInput);
            Dictionary<string,int> products = new Dictionary<string,int>();
            products.Add("Croissant", 0);
            products.Add("Muffin", 0);
            products.Add("Baguette", 0);
            products.Add("Bagel", 0);

            while (true)
            {
                if (water.Count == 0 || flour.Count == 0)
                {
                    break;
                }
                double waterToMix = water.Peek();
                double flourToMix = flour.Peek();

                double sum = waterToMix + flourToMix;
                double waterPersentage = (waterToMix * 100) / sum;
                double flourPersentage = (flourToMix * 100) / sum;

                if (waterPersentage == 50 && flourPersentage == 50)
                {
                    products["Croissant"]++;
                }
                else if (waterPersentage == 40 && flourPersentage == 60)
                {
                    products["Muffin"]++;
                }
                else if (waterPersentage == 30 && flourPersentage == 70)
                {
                    products["Baguette"]++;
                }
                else if (waterPersentage == 20 && flourPersentage == 80)
                {
                    products["Bagel"]++;
                }
                else
                {
                    
                    double neededFlour = waterToMix;
                    double leftFlour = flourToMix - neededFlour;
                    products["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                    flour.Push(leftFlour);
                    continue;
                }
                water.Dequeue();
                flour.Pop();
               
            }
            var sortedProducts = products.OrderByDescending(p => p.Value).ThenBy(p => p.Key);
            foreach (var product in sortedProducts)
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
               
            }
            
            
           
           
            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                
                    Console.WriteLine($"Water left: {string.Join(", ",water)}");
                
                
            }
            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
               
                    Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
                
            }

        }
    }
}
