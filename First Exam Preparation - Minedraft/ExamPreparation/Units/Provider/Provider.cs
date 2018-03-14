using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : Unit
{
    protected Provider(string Id, double energyOutput) : base(Id)
    {
        this.EnergyOutput = energyOutput;
    }

    private double energyOutput;

    public double EnergyOutput
    {
        get { return energyOutput; }
        private set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        return $"{Type} Provider - {Id}" + Environment.NewLine +
               $"Energy Output: {EnergyOutput}";
    }
}

