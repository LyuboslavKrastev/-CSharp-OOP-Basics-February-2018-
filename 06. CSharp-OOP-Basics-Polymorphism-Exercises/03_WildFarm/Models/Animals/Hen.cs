using System;

public class Hen : Bird
{

    public Hen(string name, double weight, double wingSze) : base(name, weight, wingSze)
    {

    }
    protected override Type[] PreferredFoods
=> new Type[] { typeof(Vegetable), typeof(Meat), typeof(Fruit), typeof(Seeds) };

    protected override double WeightIncreaseMultiplier => 0.35;

    public override string MakeSound()
    {
        return "Cluck";
    }
}