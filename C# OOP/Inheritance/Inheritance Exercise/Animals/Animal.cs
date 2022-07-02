

namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Animal
    {
        private string _name;
        private int _age;
        private string _gender;
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Gender), "Gender cannot be null or whitespace");
                }
                this._name = value;
            }
        }
        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {

                if (value <= 0)
                {
                    throw new ArgumentException(nameof(this.Age), "Invalid input!");
                }
                this._age = value;
            }
        }
        public string Gender
        {
            get
            {
                return this._gender;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Gender), "Gender cannot be null or whitespace");
                }
                this._gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}{Environment.NewLine}{this.Name} {this.Age} {this.Gender}{Environment.NewLine}{this.ProduceSound()}");

            return sb.ToString().TrimEnd();
        }

    }
}
