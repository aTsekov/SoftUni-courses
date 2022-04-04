using System;

namespace L02._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            GradesinWords(grade);
        }
        static void GradesinWords (double gradeInDigits)
        {

            if (gradeInDigits >= 2 && gradeInDigits <=2.99)
            {
                Console.WriteLine($"Fail");
            }
            else if (gradeInDigits >= 3 && gradeInDigits <= 3.49)
            {
                Console.WriteLine($"Poor");
            }
            else if (gradeInDigits >= 3.50 && gradeInDigits <= 4.49)
            {
                Console.WriteLine($"Good");
            }

            else if (gradeInDigits >= 4.50 && gradeInDigits <= 5.49)
            {
                Console.WriteLine($"Very good");
            }
            else if (gradeInDigits >= 5.50 && gradeInDigits <= 6.00)
            {
                Console.WriteLine($"Excellent");
            }
            


        }
    }
}
