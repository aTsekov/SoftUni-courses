﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
        public Pokemon(string name, string element, int healt)
        {
            Name= name;
            Element= element;
            Health= healt;  
        }
        
    }
}
