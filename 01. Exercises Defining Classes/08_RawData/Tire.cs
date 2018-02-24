using System;
using System.Collections.Generic;
using System.Text;

public class Tire
{
    private double age;
    private double pressure;

    public Tire( double pressure, double age)
    {
        this.Pressure = pressure;
        this.Age = age;
    }

    public double Pressure
    {
        get { return pressure; }
        set { pressure = value; }
    }

    public double Age
    {
        get { return age; }
        set { age = value; }
    }
}

