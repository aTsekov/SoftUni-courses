using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int goalSteps = 10000;
            string input = "";
            int sumSteps = 0;
            int inputSteps = 0;

            while (sumSteps <= goalSteps)
            {
                input = Console.ReadLine();

                if (input == "Going home")
                {
                    input = Console.ReadLine();
                    inputSteps = int.Parse(input);
                    sumSteps += inputSteps;
                    break;

                }

                inputSteps = int.Parse(input);

                sumSteps += inputSteps;

                

                
            }
            if (sumSteps >= goalSteps)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{sumSteps - goalSteps} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{goalSteps - sumSteps} more steps to reach goal.");
            }



        }
    }
}
 