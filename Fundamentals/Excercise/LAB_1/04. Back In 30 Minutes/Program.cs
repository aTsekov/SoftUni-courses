using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {

            int hours = int.Parse(Console.ReadLine());
            int mins = int.Parse(Console.ReadLine());
            int mins1 = 0;


            
            if (mins < 30)
            {
                mins += 30;
                
            }
            
            else if (mins > 30)
            {
                mins -= 30;
                hours++;
            }

            if (hours > 0)
            {



                if (hours > 23)
                {

                    hours = 0;

                }


            }


            Console.WriteLine($"{hours}:{mins:d2}");

            

        }
    }
}
