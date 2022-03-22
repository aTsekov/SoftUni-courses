using System;
using System.Collections.Generic;

namespace _04._Students
{
    
    class StudentsClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string HomeTown { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            List<StudentsClass> studentsList = new List<StudentsClass>(); // правим си лист, в който ще блъскаме всички новосъздадени студенти (обекти)

            while (command[0] != "end")
            {

                string firstName = command[0];
                string lastName = command[1];
                int age = int.Parse(command[2]);
                string city = command[3];

                // правим нов обект от въведеното в конзолата:
                StudentsClass studentsObject = new StudentsClass()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    HomeTown = city

                };

                studentsList.Add(studentsObject); // добавяме към листа обекта/студента


                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string filterCity = Console.ReadLine();
              
            foreach (StudentsClass students in studentsList)
            {
                if (students.HomeTown == filterCity)
                {
                    Console.WriteLine($"{students.FirstName} {students.LastName} is {students.Age} years old."); //тоя students тука идва от students на foreach цикъла. 
                }
            }
        }
    }
}
