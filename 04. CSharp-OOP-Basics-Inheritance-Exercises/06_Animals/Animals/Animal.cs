
using System;
using System.Text;

public abstract class Animal : ISoundProducable
{
    private const string ErrorMessage = "Invalid input!";

    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Gender
    {
        get { return gender; }
        set
        {
            ValidateGender(value);
            ValidateInput(value);
            gender = value;
        }
    }

    private static void ValidateGender(string value)
    {
        if (value != "Female" && value != "Male")
        {
            throw new ArgumentException(ErrorMessage);
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            ValidateInput(value);
            name = value;
        }
    }

    private static void ValidateInput(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(ErrorMessage);
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ErrorMessage);
            }
            age = value;
        }
    }


    public virtual string ProduceSound()
    {
        return "Why, hello there good sir!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.GetType().Name}")
            .AppendLine($"{this.Name} {this.Age} {this.Gender}")
            .AppendLine(this.ProduceSound());

        return sb.ToString().TrimEnd();
    }
}

