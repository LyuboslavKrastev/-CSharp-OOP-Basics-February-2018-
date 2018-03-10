using System;

public class Dog : Mammal
{

    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override double WeightIncreaseMultiplier => 0.40;
    protected override Type[] PreferredFoods => new Type[] { typeof(Meat) };

    public override string ToString()
    {
        var baseToString = base.ToString();
        var result = String.Format(baseToString, string.Empty);
        return result;
    }

    public override string MakeSound()
    {
        return "Woof!";
    }
}