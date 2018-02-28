
using System;
using System.Text;

public class Kitten : Cat
{
    private const string KittyGender = "Female";
    public Kitten(string name, int age) 
        : base(name, age, KittyGender) { }

    public override string ProduceSound()
    {
        return "Meow";
    }
}


