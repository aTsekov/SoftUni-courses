using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string _name;
        private int _age;

        public Person(string name, int age  )
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public  int Age

        {
            get { return this._age; }
            set
            {
                if (value < 0) // If the value of the years is smaller than 0 >> throw exeption.
                {
                    throw new Exception();
                }
                //else
                this._age=value;
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("Name: {0}, Age: {1}",this.Name,this.Age));

            return stringBuilder.ToString();
        }
    }
}
