
using System;

public class Citizen : IIdentifiable, IBirthable, IHuman, IBuyer
{
    public Citizen(string name, int age, string id, string birthDate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthDate;
    }

    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string BirthDate { get; }

    public int Food { get; private set; } = 0;

    public void BuyFood()
    {
        this.Food += 10;
    }

    public override string ToString()
    {
        return this.BirthDate;
    }

}

