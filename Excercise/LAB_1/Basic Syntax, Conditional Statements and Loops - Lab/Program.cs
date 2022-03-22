using System;

namespace Basic_Syntax__Conditional_Statements_and_Loops___Lab
{
    class Program
    {
        static void Main(string[] args)
        {

            string studentName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double aveGrade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {studentName}, Age: {age}, Grade: {aveGrade:f2}");





        }
    }
}
