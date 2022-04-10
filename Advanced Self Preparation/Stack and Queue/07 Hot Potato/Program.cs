using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ').ToArray();
            int hotPotato= int.Parse(Console.ReadLine());
            Queue<string> circle = new Queue<string>();

            for (int i = 0; i < names.Length; i++)// пълним си имената в опашката. Можем и директно да четем опашката от конзолата по същия начин като масив,лист, и т.н.
            {

                circle.Enqueue(names[i]);

            }
            while (circle.Count >1)//въртим докато не остане само едно дете. 
            {
                for (int i = 1; i < hotPotato; i++)
                {
                    string kid = circle.Dequeue(); //взимаме първото дете от опашката и го слагаме последно
                    circle.Enqueue(kid);


                }

                Console.WriteLine($"Removed {circle.Dequeue()}");// махаме новото първо дете/слаге го първо на опашката
            }
            Console.WriteLine($"Last is{circle.Dequeue()}");
            
        }
    }
}
