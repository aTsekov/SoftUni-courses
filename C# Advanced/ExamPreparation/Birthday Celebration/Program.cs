using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guestsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] foodInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> guests = new List<int>(guestsInput);
            Stack<int> food = new Stack<int>(foodInput);

            int wastedFood = 0;

            while (true)
            {
                int currentGuest = guests.First();
                int currentFood = food.Peek();

                // If the food for the current guest is enough
                if (currentFood >= currentGuest)
                {
                    wastedFood += currentFood - currentGuest;
                    guests[0] -= currentFood;
                    if (guests [0] <=0)
                    {
                        guests.RemoveAt(0); //If the first guest is filled, delete it. 
                        food.Pop();

                    }
                }
                else // if the food for the guest is not enough
                {
                    
                    while (guests.Count != 0)
                    {
                        if (food.Count == 0)
                        {
                            break;
                        }
                        guests[0] -= currentFood;
                        if (guests[0] > 0) // if the guest needs more food
                        {
                            food.Pop();// remove the food because it is 0. 
                            currentFood = food.Peek();//get the next food.
                        }
                        
                        else// if the guest does not need more food
                        {
                            wastedFood += Math.Abs(guests[0]);
                            guests.RemoveAt(0); //If the first guest is filled, delete it. 
                            food.Pop();
                            if (food.Count != 0)
                            {
                                currentFood = food.Peek();
                            }
                            
                        }


                        if (guests.Count == 0)
                        {
                            break;
                        }
                    }
                }
                if (guests.Count == 0)// if all guests are filled.
                {
                    food.Reverse();
                    Console.WriteLine($"Plates: {string.Join(' ',food)}");
                    Console.WriteLine($"Wasted grams of food: {wastedFood}");
                    break;
                }
                else if(food.Count == 0)
                {
                    Console.WriteLine($"Guests: {string.Join(' ',guests)}");
                    Console.WriteLine($"Wasted grams of food: {wastedFood}");
                    break;
                }
            }
        }
    }
}
