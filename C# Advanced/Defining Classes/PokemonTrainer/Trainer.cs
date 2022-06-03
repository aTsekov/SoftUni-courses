using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private int numOfBadges = 0;
        public string TrainerName { get; set; }
        public int NumberOfBadges
        {
            get { return numOfBadges; }
            set { numOfBadges = value; }
        }
        public List<Pokemon> PokemonList { get; set; }
        
        public Trainer(string name)
        {
            TrainerName = name;
            PokemonList = new List<Pokemon>();
            NumberOfBadges = numOfBadges;
            
        }

    }
}
