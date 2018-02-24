using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; } 
    public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    public List<Person> Parents { get; set; } = new List<Person>();
    public List<Person> Children { get; set; } = new List<Person>();

    public Person(string name)
    {
        this.Name = name;
    }
    public Person(string name, string birthday) :this(name)
    {
        this.BirthDay = birthday;
    }

    public string BirthDay { get; set; }

    public void PrintPokemons()
    {
        this.Pokemons.ForEach(p => Console.WriteLine(p));
    }
    public void PrintParents()
    {
        this.Parents.ForEach(p => Console.WriteLine(p));
    }
    public void PrintChildren()
    {
        this.Children.ForEach(p => Console.WriteLine(p));
    }
    public void PrintCar()
    {
        if (this.Car!= null)
        {
            Console.WriteLine(this.Car);
        }     
    }
    public void PrintCompany()
    {
        if (this.Company != null)
        {
            Console.WriteLine(this.Company);
        }        
    }
    public override string ToString()
    {
        return $"{this.Name} {this.BirthDay}";
    }
}
public class Company
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public Company(string name, string department, decimal salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Department} {this.Salary:f2}";
    }
}
public class Pokemon
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Pokemon(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Type}";
    }
}
public class Car
{
    public string Model { get; set; }
    public double Speed { get; set; }
    public Car()
    {

    }
    public Car(string model, double speed)
    {
        this.Model = model;
        this.Speed = speed;
    }
    public override string ToString()
    {
        return $"{this.Model} {this.Speed}";
    }
}
