using System;

public class Cat : Feline
{

    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    protected override double WeightIncreaseMultiplier => 0.30;
    protected override Type[] PreferredFoods => new Type[] { typeof(Meat), typeof(Vegetable) };

    public override string MakeSound()
    {
        return "Meow";
    }
}
