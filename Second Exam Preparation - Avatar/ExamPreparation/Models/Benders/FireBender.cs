public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAgression) : base(name, power)
    {
        this.HeatAgression = heatAgression;
    }

    public double HeatAgression { get; private set; }

    public override double GetTotalPower()
    {
        return this.HeatAgression * this.Power;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Heat Agression: {this.HeatAgression:f2}";
    }
}

