using System;
using System.Collections.Generic;

namespace _007__Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

           // string [] studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<double>> studentDict = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine()); 
                int gradeCounter = 0;

                if (!studentDict.ContainsKey(studentName))
                {
                    gradeCounter++;
                    studentDict.Add(studentName, new List<double>() { studentGrade, gradeCounter });
                }
                else
                {
                    gradeCounter = 1;
                    studentDict[studentName][0] += studentGrade;
                    studentDict[studentName][1] += gradeCounter;
                }

            }


            foreach (var student in studentDict)
            {
                double averageGrade = (student.Value[0] / student.Value[1]);

                if (averageGrade >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {averageGrade:f2}");
                }
                
            }


        }
    }
}
