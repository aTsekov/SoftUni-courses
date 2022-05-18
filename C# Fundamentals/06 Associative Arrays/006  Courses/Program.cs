using System;
using System.Collections.Generic;
using System.Linq;

namespace _006__Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseInfo = new Dictionary<string, List<string>>();

            string command;

            while((command = Console.ReadLine()) != "end")
            {
                string [] courseArgs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string courseName = courseArgs[0];
                string studentName = courseArgs[1];
                if (!courseInfo.ContainsKey(courseName))
                {
                    //courseInfo.Add(courseName, new List<string>() {studentName});
                    courseInfo[courseName] = new List<string>(); // на ключа от речника, му слагам нов лист като стойност
                }
                courseInfo[courseName].Add(studentName); // на този ключ му доваби стойност (към списъка)

            }
            Print(courseInfo);
        }
        static void Print (Dictionary<string, List<string>> CourseInfo)
        {
            foreach (var kvp in CourseInfo)
            {
                string courseName = kvp.Key;
                List<string> students = kvp.Value;

                Console.WriteLine($"{courseName}: {students.Count}");

                foreach (string studentName in students)
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
    }
}
