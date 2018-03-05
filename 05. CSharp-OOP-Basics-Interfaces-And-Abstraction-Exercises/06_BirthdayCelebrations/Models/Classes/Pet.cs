using System;

class Pet : IBirthable
{
    public Pet(string name, string birthDate)
    {
        this.Name = name;
        this.BirthDate = birthDate;
    }

    public string Name { get; }

    public string BirthDate { get; }

    public override string ToString()
    {
        return this.BirthDate;
    }

}

