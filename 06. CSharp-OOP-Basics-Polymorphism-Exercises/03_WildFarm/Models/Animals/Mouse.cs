using System;

public class Mouse : Mammal
{

    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override double WeightIncreaseMultiplier => 0.10;
    protected override Type[] PreferredFoods => new Type[] { typeof(Fruit), typeof(Vegetable) };

    public override string ToString()
    {
        var baseToString = base.ToString();
        var result = String.Format(baseToString, string.Empty);
        return result;
    }
    public override string MakeSound()
    {
        return "Squeak";
    }
}