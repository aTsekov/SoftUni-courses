using System;

namespace _01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int emplOneEfficiency = int.Parse(Console.ReadLine());
            int emplTwoEfficiency = int.Parse(Console.ReadLine());
            int emplThreeEfficiency = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            int totalHoursNeeded = 0;
            int hours = 0;

            int combinedPowerPerHour = emplOneEfficiency + emplTwoEfficiency + emplThreeEfficiency;

            for (int i = studentsCount; i > 0; i--)
            {
                studentsCount -= combinedPowerPerHour;
                hours++;
                
                if (hours == 4)
                {
                    hours = 0;
                    studentsCount += combinedPowerPerHour;
                    totalHoursNeeded++;
                    continue;
                }
                totalHoursNeeded++;
                if (studentsCount <= 0)
                {
                    Console.WriteLine($"Time needed: {totalHoursNeeded}h.");

                    break;
                }

            }
        }
    }
}
