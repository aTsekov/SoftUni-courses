using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : ICreature
    {
        
        public Citizen(string birthday)
        {
            this.Birthday = birthday;
        }
        public string Name { get; private set; }

        public string Birthday {get; private set; }
    }
}
