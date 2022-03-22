using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int fails = int.Parse(Console.ReadLine());
            string excerciseName = "";
            int failsCounter = 0;
            double mark = 0;
            int markCounter = 0;
            double markSum = 0;
            int excerciseCounter = 0;
            string lastExcerciseName = "";


            while (excerciseName != "Enough")
            {
                
                
                excerciseName = Console.ReadLine();
                if (excerciseName == "Enough")
                {
                    break;
                }

                lastExcerciseName = excerciseName;
                excerciseCounter++;
                mark = int.Parse(Console.ReadLine());
                markSum += mark;
                markCounter++;

                if (mark <= 4)
                {
                    failsCounter++;
                    if (fails == failsCounter)
                    {
                        break;
                    }
                }
                

            }

            double averageMark = markSum / markCounter;

            if (excerciseName == "Enough")
            {
                Console.WriteLine($"Average score: {averageMark:f2}");
                Console.WriteLine($"Number of problems: {excerciseCounter}");
                Console.WriteLine($"Last problem: {lastExcerciseName}");
            }
            else
            {
                Console.WriteLine($"You need a break, {failsCounter} poor grades. ");
            }





        }
    }
}
