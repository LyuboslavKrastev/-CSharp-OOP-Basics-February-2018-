using System;
using System.Text;

class Engine
{
    private const string offset = "  ";

    public string model;
    public int power;
    public string displacement = "n/a";
    public string efficiency = "n/a";

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
    }

    public Engine(string model, int power, string displacement) : this(model, power)
    {
        if (int.TryParse(displacement, out _))
        {
            this.displacement = displacement;
        }
        else
        {
            this.efficiency = displacement;
        }
        
    }


    public Engine(string model, int power, string displacement, string efficiency) : this(model, power, efficiency)
    {
        this.displacement = displacement;
    }



    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat($"{offset}{this.model}:{Environment.NewLine}");
        sb.AppendFormat($"{offset}{offset}Power: {this.power}{Environment.NewLine}");
        sb.AppendFormat($"{offset}{offset}Displacement: {this.displacement}{Environment.NewLine}");
        sb.AppendFormat($"{offset}{offset}Efficiency: {this.efficiency}{Environment.NewLine}");

        return sb.ToString();
    }
}