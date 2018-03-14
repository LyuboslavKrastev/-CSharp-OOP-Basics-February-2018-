using System;
using System.Collections.Generic;
using System.Text;

public class SolarProvider : Provider
{
    public SolarProvider(string Id, double energyOutput) : base(Id, energyOutput)
    {
    }

    public override string Type => "Solar";
}

