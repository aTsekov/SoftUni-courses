using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryNum = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double grade = 0;
            double currentGrade = 0;
            int counter = 0;
            double averageGrade = 0;
            int counterAve = 0;
            double firstAve = 0;

            while (presentationName != "Finish")
            {
                for (int i = 1; i <= juryNum; i++)
                {
                    grade = double.Parse(Console.ReadLine());

                    currentGrade += grade;
                    counter++;
                    
                }

                averageGrade += currentGrade;         
                
                Console.WriteLine($"{presentationName} - {currentGrade / juryNum:f2}.");

                currentGrade = 0;
                presentationName = Console.ReadLine();

            }

            Console.WriteLine($"Student's final assessment is {averageGrade/counter:f2}.");


        }
    }
}
