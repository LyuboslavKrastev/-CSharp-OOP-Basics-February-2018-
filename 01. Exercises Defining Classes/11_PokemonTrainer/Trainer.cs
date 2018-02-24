using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Trainer
{
    private string name;
    private int numberOfBadges = 0;
    private List<Pokemon> pokemons;

    public Trainer()
    {
        pokemons = new List<Pokemon>();
    }
    public Trainer(string name, Pokemon pokemon): this()
    {
        this.Name = name;
        this.Pokemons.Add(pokemon);
    }

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }


    public int NumberOfBadges
    {
        get { return numberOfBadges; }
        set { numberOfBadges = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        return $"{this.name} {this.numberOfBadges} {this.pokemons.Count}";
    }
    public void RemoveDeadPokemons()
    {
        var deadPokemons = this.Pokemons.Where(p => p.Health <= 0);
        if (deadPokemons.Any())
        {
            this.Pokemons = this.Pokemons.Except(deadPokemons).ToList();
        }
    }
}

