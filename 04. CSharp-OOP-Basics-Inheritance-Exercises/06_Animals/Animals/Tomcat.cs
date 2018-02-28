using System;
using System.Text;

public class Tomcat : Cat
{
    private const string TomGender = "Male";
    public Tomcat(string name, int age)
        : base(name, age, TomGender) { }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}


