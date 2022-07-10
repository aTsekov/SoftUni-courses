﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : ICitizen
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public Citizen(string id)
        {
            this.Id=id;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }
    }
}
