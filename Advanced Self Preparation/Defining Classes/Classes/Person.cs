using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name; // field. It can be used only in the class because it is private
        private int age;

        public Person() // ctor with default values
        {
            this.Name = "No name";
            this.Age = 1;
        }
        public Person(int age) : this()
        {
            Age = age;
        }
        public Person(string name, int age) :this(age)
        {
            Name = name;            
        }
        public string Name // property. It is visible everywhere because the property is public 
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age 
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
}
