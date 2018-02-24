
using System;
using System.Collections.Generic;
using System.Linq;

public class OpinionPoll
    {
    private List<Person> people { get; set; } = new List<Person>();



    public void AddPerson(Person person)
    {
        if (person.Age > 30)
        {
            this.people.Add(person);
        }
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, people.OrderBy(p => p.Name));
    }
}

