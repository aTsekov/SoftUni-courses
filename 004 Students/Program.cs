using System;
using System.Collections.Generic;
using System.Linq;

namespace _004_Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> listOfStudents = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(' ');
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                double grade = double.Parse(studentInfo[2]);

                Student newStudent = new Student(firstName, lastName, grade);

                listOfStudents.Add(newStudent);
            }
            listOfStudents = listOfStudents.OrderByDescending(s => s.Grade).ToList();
            foreach (Student student in listOfStudents)
            {
                Console.WriteLine(student);
            }

            
        }
        class Student
        {
            public Student(string firstName, string lastName, double grade)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Grade = grade;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
            }

        }
    }
}
