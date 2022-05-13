using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] familyInfo = Console.ReadLine().Split(" ");

                string name = familyInfo[0];
                int age = int.Parse(familyInfo[1]); 

                Person person = new Person(name, age);

                
                family.AddMember(person);
            }
            Person oldest = family.GetOldestPerson();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");


            
        }
    }
}
