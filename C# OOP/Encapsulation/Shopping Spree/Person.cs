using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List <Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List <Product>();
            
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                money = value;
            }
        }
        public List<Product> Products { get; set; }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void ReduceMoney(Product product)
        {
            money -= product.Cost;
        }
        public override string ToString()
        {
            if (this.Products.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", Products.Select(p => p.Name))}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }

}
