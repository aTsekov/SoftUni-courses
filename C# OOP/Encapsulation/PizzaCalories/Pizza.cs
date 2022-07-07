using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private int numberOfToppings = 10;
        private double totalCalories;
        public Pizza(string name)
        {
            this.Name = name;
            Toppings = new List<Topping>();

        }
        public Pizza()
        {
           
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough { get; set; }
        public List<Topping> Toppings { get; set; }
        public Topping Topping { get; set; }
        public int NumberOfToppings => Toppings.Count;
        
        public double TotalCalories => Toppings.Sum(t => t.toppingCalories) + Dough.calories;

        public void AddTopping(Topping topping)
        {
            if (numberOfToppings == Toppings.Count)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            else
            {
                Toppings.Add(topping);
            }
        }

    }
}


