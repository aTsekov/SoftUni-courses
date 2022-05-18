using System;
using System.Collections.Generic;
using System.Linq;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ");
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                Person person = new Person(name, age);

                people.Add(person);
            }

            List<Person> orderedPeople = people.Where(x => x.Age > 30).OrderBy(p => p.Name).ToList();

            foreach (var person in orderedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
