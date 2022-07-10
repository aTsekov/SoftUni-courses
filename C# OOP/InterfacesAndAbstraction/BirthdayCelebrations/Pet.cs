using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : ICreature
    {
        public Pet(string birthday)
        {
            this.Birthday = birthday;
        }
        public string Name { get; private set; }

        public string Birthday { get; private set; }

    }
}
