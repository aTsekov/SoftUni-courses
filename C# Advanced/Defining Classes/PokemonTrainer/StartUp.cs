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
            List<Trainer> trainers = new List<Trainer>();
            while ((info = Console.ReadLine()) != "Tournament")
            {
                string[] data = info.Split(' ');
                string trainerName = data[0];
                string pokemonName = data[1];
                string element = data[2];
                int pokemonHealt = int.Parse(data[3]);
                Pokemon pokemon = new Pokemon(pokemonName, element, pokemonHealt);
                Trainer trainer = new Trainer(trainerName);
                trainer.PokemonList.Add(pokemon);

                if (!trainers.Any(t => t.TrainerName == trainerName))
                {
                    trainers.Add(trainer);
                }
                else
                {
                    foreach (var tr in trainers)
                    {
                        if (tr.TrainerName == trainerName)
                        {
                            tr.PokemonList.Add(pokemon);
                        }
                    }
                }
            }

            string elementType = string.Empty;
            while ((elementType = Console.ReadLine()) != "End")
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
                Console.WriteLine($"{trainer.TrainerName} {trainer.NumberOfBadges} {trainer.PokemonList.Count}");
            }
        }

        private static void TrainerPokemonElement(List<Pokemon> pokemonList, List<Trainer> trainers, string elementType)
        {
            Pokemon pokemoneTORemove = new Pokemon();
            foreach (var trainer in trainers)
            {
                if (trainer.PokemonList.Count == 0)
                {
                    continue;
                }


                Pokemon currPokemon = trainer.PokemonList[0];

                if (currPokemon.Element == elementType)
                {
                    foreach (var pokemon in trainer.PokemonList)
                    {
                        trainer.NumberOfBadges++;
                    }

                }
                else
                {
                    currPokemon.Health -= 10;
                    if (currPokemon.Health <= 0)
                    {
                        trainer.PokemonList.RemoveAll(p => p.PokemonName == currPokemon.PokemonName);

                    }
                }
            }
        }
    }
}
