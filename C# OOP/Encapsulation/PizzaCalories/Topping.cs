using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sause = 0.9;
        private const double grams = 2;

        private double toppingGrams;//
        private string toppingType;//
        private double weightGrams;//
        public Topping(string toppingType,double grams)
        {
            this.ToppingType = toppingType;
            this.WeightGrams = grams;
        }

        public string ToppingType
        {
            get { return toppingType; }
            set
            {
                if (value.ToLower() == "Meat".ToLower())
                {
                    toppingGrams = meat;
                }
                else if (value.ToLower() == "Veggies".ToLower())
                {
                    toppingGrams = veggies;
                }
                else if (value.ToLower() == "Cheese".ToLower())
                {
                    toppingGrams = cheese;
                }
                else if (value.ToLower() == "Sauce".ToLower())
                {
                    toppingGrams = sause;
                }
                else
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }
        public double WeightGrams
        {
            get { return weightGrams; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.ToppingType} weight should be in the range [1..50].");
                }
                weightGrams = value;
            }
        }
        public double toppingCalories => grams * this.WeightGrams * this.toppingGrams;


    }
}
