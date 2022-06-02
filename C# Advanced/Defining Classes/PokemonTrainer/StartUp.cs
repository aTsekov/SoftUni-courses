using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string info = string.Empty;
            List<Pokemon> pokemonList = new List<Pokemon>();
            List <Trainer> trainers = new List<Trainer>();
            while ((info = Console.ReadLine())!= "Tournament")
            {
                string[] data = info.Split(' ');
                string trainerName = data[0];
                string pokemonName = data[1];
                string element = data[2];
                int pokemonHealt = int.Parse(data[3]);
                Pokemon pokemon = new Pokemon(pokemonName, element, pokemonHealt);
                pokemonList.Add(pokemon);

                Trainer trainer = new Trainer(trainerName, pokemonList);
                trainers.Add(trainer);
            }

            string elementType = string.Empty;
            while ((elementType = Console.ReadLine())!= "End")
            {

                if (elementType == "Fire")
                {
                    TrainerPokemonElement(pokemonList, trainers, elementType);
                }
                else if (elementType == "Water")
                {
                    TrainerPokemonElement(pokemonList, trainers, elementType);
                }
                else if (elementType == "Electricity")
                {
                    TrainerPokemonElement(pokemonList, trainers, elementType);
                }

            }

            List<Trainer> sortedTrainer = trainers.OrderByDescending(n => n.NumberOfBadges).ToList();

            foreach (var trainer in sortedTrainer)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.PokemonList.Count}");
            }
        }

        private static void TrainerPokemonElement(List<Pokemon> pokemonList, List<Trainer> trainers, string elementType)
        {
            Pokemon pokemoneTORemove = new Pokemon();
            foreach (var trainer in trainers)
            {
                
                foreach (var pokemon in trainer.PokemonList) ///
                {
                    if (pokemon.Element == elementType)
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        pokemon.Health -= 10;
                        if (pokemon.Health <= 0)
                        {

                            pokemoneTORemove = pokemon;
                            
                        }
                    }
                }
                pokemonList.Remove(pokemoneTORemove);
            }
        }
    }
}
