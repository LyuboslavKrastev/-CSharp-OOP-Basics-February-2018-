
public class Person
{
    private int age;
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Person()
    {
        this.Age = 1;
        this.Name = "No name";
    }
    public Person(int age)
    {
        this.Name = "No name";
        this.Age = age;
    }
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        //  return $"{this.name} {this.age}"; // problem 3
        return $"{this.name} - {this.age}"; // problem 4
    }
}

