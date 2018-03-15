using System;
using System.Collections.Generic;
using System.Text;
public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; private set; }

    public override double GetTotalPower()
    {
        return this.GroundSaturation * this.Power;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Ground Saturation: {this.GroundSaturation:f2}";
    }

}

