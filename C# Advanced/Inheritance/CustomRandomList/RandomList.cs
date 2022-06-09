using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public Random Random { get; set; }
        public RandomList()
        {
            Random = new Random();
        }
        public string RandomString()
        {
            string stringToReturn = string.Empty;
            int index = Random.Next(0, this.Count);
            stringToReturn = this[index];
            this.RemoveAt(index);
            return stringToReturn;
            
        }

    }
}
