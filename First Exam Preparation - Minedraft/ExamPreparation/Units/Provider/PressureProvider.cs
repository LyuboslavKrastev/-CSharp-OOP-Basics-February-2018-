using System;
using System.Collections.Generic;
using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string Id, double energyOutput) 
        : base(Id, energyOutput * 1.5)
    {

    }
    public override string Type => "Pressure";

}

