using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string name { get; set; }
    public string birthDay { get; set; }
    public HashSet<Person> Parents { get; set; } = new HashSet<Person>();
    public HashSet<Person> Children { get; set; } = new HashSet<Person>();
    public Person()
    {

    }
    public Person(string name, string birthDay)
    {
        this.name = name;
        this.birthDay = birthDay;
    }
    public override string ToString()
    {
        return $"{this.name} {this.birthDay}";
    }
}

