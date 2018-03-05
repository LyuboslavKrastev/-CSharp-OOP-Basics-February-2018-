using System;
using System.Collections.Generic;
using System.Text;
public class Rebel : IHuman, IBuyer
{
    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }
    public string Name { get; }

    public int Age { get; }

    public string Group { get; }

    public int Food { get; private set; } = 0;

    public void BuyFood()
    {
        this.Food += 5;
    }
}

