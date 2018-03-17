
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.HorsePower += this.HorsePower * 50 / 100;
        this.Suspension -= this.Suspension * 25 / 100;
        this.addOns = new List<string>();
    }

    public override string ToString()
    {
        var result = new StringBuilder(base.ToString());

        if (this.addOns.Any())
        {
            result.AppendLine($"Add-ons: {string.Join(", ", addOns)}");
        }
        else
        {
            result.AppendLine($"Add-ons: None");
        }

        return result.ToString().TrimEnd();
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.addOns.Add(addOn);
    }
}

