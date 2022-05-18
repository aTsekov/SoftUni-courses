using System;
using System.Collections.Generic;
using System.Linq;

namespace L05_Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string [] parts = line.Split(", ");
                string name = parts[0];
                int age = int.Parse(parts[1]);

                Person person = new Person();
                person.Name = name;
                person.Age = age;

                people.Add(person);
            }
            string filterName = Console.ReadLine(); //yonger/older/exact
            int ageToCompareWith = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = p => true; // this funn has two paramiters - the class Person so we can access each person from the class and a true/false. 

            if (filterName == "younger")
            {
                filter = p => p.Age < ageToCompareWith; // returns the people that are below the specified age. 
            }
            else if (filterName == "older")
            {
                filter = p => p.Age >= ageToCompareWith;
            }


            var filteredPeople = people.Where(filter);
            var PrintName = Console.ReadLine();
            Func<Person, string> printFunc = p => p.Name + " - " + p.Age;

            if (PrintName == " name age")
            {
                printFunc = p => p.Name + " " + p.Age;
            }
            else if (PrintName == "name")
            {
                printFunc = p => p.Name;
            }
            else if (PrintName == "age")
            {
                printFunc = p => p.Age.ToString();
            }
            var PersonAsString = filteredPeople.Select(printFunc);

            foreach (var item in PersonAsString)
            {
                Console.WriteLine(item);
            }

        }
        class Person
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
