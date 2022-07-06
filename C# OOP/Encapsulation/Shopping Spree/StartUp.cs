using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Spree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            try
            {

                List<Person> people = new List<Person>();

                string[] peopleInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var person in peopleInfo)
                {
                    string[] parts = person.Split('=');
                    string name = parts[0];
                    decimal value = decimal.Parse(parts[1]);
                    Person person1 = new Person(name, value);

                    people.Add(person1);
                }

                List<Product> products = new List<Product>();

                string[] productInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var product in productInfo)
                {
                    string[] parts = product.Split('=');
                    string productName = parts[0];
                    decimal productValue = decimal.Parse(parts[1]);
                    Product productProduct = new Product(productName, productValue);
                    products.Add(productProduct);
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] tokens = command.Split(' ');
                    string personName = tokens[0];
                    string productName = tokens[1];

                    var currentPerson = people.FirstOrDefault(p => p.Name == personName);
                    var currnetProduct = products.FirstOrDefault(p => p.Name == productName);
                    if (currentPerson.Money >= currnetProduct.Cost)
                    {
                        currentPerson.AddProduct(currnetProduct);
                        currentPerson.ReduceMoney(currnetProduct);
                        Console.WriteLine($"{currentPerson.Name} bought {currnetProduct.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{currentPerson.Name} can't afford {currnetProduct.Name}");
                    }
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);

            }


        }
    }
}
