using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           Person person = new Person();

            person.Name = "Antoni";
            person.Age = 29;

            Console.WriteLine(person.Name);
        }
    }
}
