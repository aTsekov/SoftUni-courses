using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }
        public Animal(string name, string faviouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = faviouriteFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my faviourite food is {this.FavouriteFood}";
        }

    }
}
