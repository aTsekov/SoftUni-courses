using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private int numOfBadges = 0;
        public string Name { get; set; }
        public int NumberOfBadges
        {
            get { return numOfBadges; }
            set { numOfBadges = value; }
        }
        public List<Pokemon> PokemonList { get; set; }
        
        public Trainer(string name, List<Pokemon> pokemonList)
        {
            Name = name;
            PokemonList = new List<Pokemon>();
            PokemonList = pokemonList;
        }

    }
}
