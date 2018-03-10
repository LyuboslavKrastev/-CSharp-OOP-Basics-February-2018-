using System;

public class Tiger : Feline
{

    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    protected override double WeightIncreaseMultiplier => 1;
    protected override Type[] PreferredFoods => new Type[] { typeof(Meat) };

    public override string MakeSound()
    {
        return "ROAR!!!";
    }
}