using System;
using System.Collections.Generic;
using System.Text;

    public class Cargo
    {
    private int weight;
    private string type;


    public Cargo(int cargoWeight, string cargoType)
    {
        this.Weight = cargoWeight;
        this.Type = cargoType;
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

}

