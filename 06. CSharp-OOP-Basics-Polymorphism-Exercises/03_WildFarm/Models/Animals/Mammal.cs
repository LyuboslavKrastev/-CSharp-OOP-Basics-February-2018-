﻿public abstract class Mammal : Animal
{

    public Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion { get; set; }


    public override string ToString()
    {
        var baseToString = base.ToString();
        var result = string.Format(baseToString, "{0}", $" {this.LivingRegion}, ");
        return result;
    }
}