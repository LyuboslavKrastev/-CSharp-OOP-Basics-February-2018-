using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split();

            var name = tokens[0];
            var country = tokens[1];
            var age = int.Parse(tokens[2]);

            IPerson person = new Citizen(name, country, age);
            IResident resident = new Citizen(name, country, age);

            Print(person, resident);
        }
    }

    private static void Print(IPerson person, IResident resident)
    {
        Console.WriteLine(person.GetName());
        Console.WriteLine(resident.GetName());
    }
}