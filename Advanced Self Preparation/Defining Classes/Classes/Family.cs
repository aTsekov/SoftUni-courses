using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {

            FamilyMembers = new List<Person>();
        }
        public List<Person> FamilyMembers { get; set; } 

        public void AddMember (Person person)
        {
            FamilyMembers.Add (person);
        }
        public Person GetOldestPerson()
        {
            Person oldestPerson = FamilyMembers.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPerson;
        }
    }
}
