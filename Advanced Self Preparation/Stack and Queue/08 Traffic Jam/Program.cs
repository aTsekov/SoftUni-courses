using System;
using System.Collections.Generic;

namespace _08_Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsToPass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passedCarsCounter = 0;

            string car;
            while ((car = Console.ReadLine()) != "end")
            {

                if (car =="green")
                {
                    
                    
                        for (int i = 0; i < carsToPass; i++)
                        {
                            if (cars.Count > 0) 
                            { 
                                string carToPass = cars.Dequeue();
                                Console.WriteLine($"{carToPass} passed!");
                                passedCarsCounter++;
                            }
                        }
                    
                    
                    continue;
                }

                cars.Enqueue(car);


            }
            Console.WriteLine($"{passedCarsCounter} cars passed the crossroads.");
        }
    }
}
