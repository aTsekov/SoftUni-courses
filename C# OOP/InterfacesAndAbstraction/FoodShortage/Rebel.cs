using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        private string name;
        public Rebel(string name)
        {
            this.Name = name;
            
        }
        public Rebel()
        {

        }
       
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            Food += 5;
        }
        
    }
}
