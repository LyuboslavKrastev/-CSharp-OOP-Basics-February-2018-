using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; } = "n/a";
    public string Color { get; set; } = "n/a";

    public override string ToString()
    {
        var result = $"{this.Model}:" + Environment.NewLine + $"  {this.Engine.Model}:"
            + Environment.NewLine
            + $"    Power: {this.Engine.Power}"
            + Environment.NewLine
            + $"    Displacement: {this.Engine.Displacement}"
            + Environment.NewLine
            + $"    Efficiency: {this.Engine.Efficiency}"
            + Environment.NewLine
            + $"  Weight: {this.Weight}"
            + Environment.NewLine
            + $"  Color: {this.Color}";
        return result;
    }
}

