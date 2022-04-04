using System;

namespace _04._Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            int studentsNum = int.Parse(Console.ReadLine());
            double gradeEachStudent = 0;
            int firstGroup = 0;
            int secondGroup = 0;
            int thirdGroup = 0;
            int forthGroup = 0;
            double averageGrade = 0;


            for (int i = 1; i <= studentsNum; i++)
            {
                gradeEachStudent = double.Parse(Console.ReadLine());

                if (gradeEachStudent >= 2 && gradeEachStudent <= 2.99)
                {
                    firstGroup++;
                }
                else if (gradeEachStudent >= 3 && gradeEachStudent <= 3.99)
                {
                    secondGroup++;
                }
                else if (gradeEachStudent >= 4 && gradeEachStudent <= 4.99)
                {
                    thirdGroup++;
                }
                else if (gradeEachStudent >= 5 && gradeEachStudent <= 6)
                {
                    forthGroup++;
                }

                averageGrade += gradeEachStudent;

            }

            double totalAverage = averageGrade / studentsNum;
            double percentageFirstGroup = ((double)firstGroup / studentsNum) *100;
            double percentageSecondGroup = ((double)secondGroup / studentsNum) * 100;
            double percentageThirdGroup = ((double)thirdGroup / studentsNum) * 100;
            double percentageForthGroup = ((double)forthGroup / studentsNum) * 100;

            Console.WriteLine($"Top students: {percentageForthGroup:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {percentageThirdGroup:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {percentageSecondGroup:f2}%");
            Console.WriteLine($"Fail: {percentageFirstGroup:f2}%");
            Console.WriteLine($"Average: {totalAverage:f2}");



        }
    }
}
