using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamProblemMealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mealsArr = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            int [] calories = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int salad = 350;
            int soup = 490;
            int pasta = 680;
            int steak = 790;
            int mealcounter = 0;

            Queue<string> meals = new Queue<string>(mealsArr);
            Stack<int> caloriesPerDay = new Stack<int>(calories);
           

            
                int currentDayCals = caloriesPerDay.Peek();
               
                while (currentDayCals > 0 && meals.Count > 0 )
                {
                    string currentMeal = meals.Peek();
                    
                        if (currentMeal == "salad")
                        {
                            currentDayCals -= salad;
                            meals.Dequeue();
                            mealcounter++;
                        }
                        else if (currentMeal == "soup")
                        {
                            currentDayCals -= soup;
                            meals.Dequeue();
                            mealcounter++;
                        }
                        else if (currentMeal == "pasta")
                        {
                            currentDayCals -= pasta;
                            meals.Dequeue();
                            mealcounter++;
                        }
                        else if (currentMeal == "steak")
                        {
                            currentDayCals -= steak;
                            meals.Dequeue();
                            mealcounter++;

                        }
                        if (currentDayCals < 0)
                        {
                            int calloriesToCompensate = currentDayCals;
                            caloriesPerDay.Pop();
                            if (caloriesPerDay.Count == 0)
                            {
                                //mealcounter--;
                                 break;
                            }
                            currentDayCals = caloriesPerDay.Peek();
                            currentDayCals += calloriesToCompensate;
                            caloriesPerDay.Pop();
                            caloriesPerDay.Push(currentDayCals);

                        }
                        


                }

                


            if (meals.Count == 0)
            {
                caloriesPerDay.ToArray();
                Console.WriteLine($"John had {mealcounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine( $"John ate enough, he had {mealcounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
            
        }
    }
}
