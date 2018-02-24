using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem11.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var trainers = new HashSet<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                var pokeInfo = input.Split();
                var trainerName = pokeInfo[0];
                var pokeName = pokeInfo[1];
                var pokeElement = pokeInfo[2];
                var pokeHealth = double.Parse(pokeInfo[3]);

                var pokemon = new Pokemon(pokeName, pokeElement, pokeHealth);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    var trainer = new Trainer(trainerName, pokemon);
                    trainers.Add(trainer);
                    continue;
                }
                var currentTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                currentTrainer.Pokemons.Add(pokemon);

            }

            while ((input = Console.ReadLine()) != "End")
            {
                var element = input;

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                    }
                    trainer.RemoveDeadPokemons();
                }
            }
            PrintTrainers(trainers);
        }

        private static void PrintTrainers(HashSet<Trainer> trainers)
        {
            foreach (var trainer in trainers.OrderByDescending(p => p.NumberOfBadges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
