using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IBuyer
    {
        public string Name { get;}
        public int Age { get;}
        public string Group { get;}
        public int Food { get;}
        void BuyFood();
        
        
    }
}
