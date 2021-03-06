﻿using System;
using System.Collections.Generic;
using System.Text;

    public class Pokemon
    {
    private string name;
    private string element;
    private double health;

    public Pokemon(string pokeName, string pokeElement, double pokeHealth)
    {
        this.Name = pokeName;
        this.Element = pokeElement;
        this.Health = pokeHealth;
    }

    public double Health
    {
        get { return health; }
        set { health = value; }
    }


    public string Element
    {
        get { return element; }
        set { element = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }


}
