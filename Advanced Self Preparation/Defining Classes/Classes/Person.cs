using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name; // field. It can be used only in the class because it is private
        private int age;

        public string Name { get; set; } // property. It is visible everywhere because the property is public 
        

        public int Age // this is the second way of doing a property
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
