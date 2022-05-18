using System;
using System.Collections.Generic;
using System.Linq;

namespace _007._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<PersonInfo> persons = new List<PersonInfo>(); // правим лист в който ще държим всички новосъздадени обекти - в случая хора.


            while (command != "End")
            {
                string[] inputTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = inputTokens[0];
                string id = inputTokens[1];
                int age = int.Parse(inputTokens[2]);


                PersonInfo personInfo = new PersonInfo (name, id, age); // правим нов обект на всяко завъртане на цикъла
                personInfo.Name = name;
                personInfo.ID = id;
                personInfo.Age = age;
                persons.Add(personInfo);

                int currentIndex = persons.FindIndex(x => x.ID == id); // намираме индекса, на който се намира ID-то на човека в листа. 

                if (currentIndex == -1) // ако индекса е невалиден, тоест ID-то не е намерено, го добавяме към списъка с хора. 
                {
                    persons.Add(personInfo);
                }
                else // ако обаче ID-то е намерено, то тогава на индекса на ID-то (в листа) слагаме новия обект. Защото, ако има човек със съществуващо ID в листа, заменяме стария човек с новия. Тоес, ако има двама човека с едно и също ID премахваме стария човек и слагаме новия. 
                {
                    persons[currentIndex] = personInfo;
                }
                command = Console.ReadLine();
                                
            }

            List<PersonInfo> orderedPeople = persons.OrderBy(x => x.Age).ToList(); // подреждаме новосъздадения лист по години на човека и принтираме
            foreach (PersonInfo item in orderedPeople)
            {
                Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
            }
        }
    }
    class PersonInfo // правим си клас
    {
        public PersonInfo(string name, string id, int age)  // правим си конструктор с бъдещите променливи, които ще получаваме и ще правим новия обект с тях. 
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
            
        }
        
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }
    }

}
