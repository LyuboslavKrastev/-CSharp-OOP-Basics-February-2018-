using System;
using System.Linq;

public class Engine
{
    private string input;
    private NationsBuilder builder;

    public Engine()
    {
        this.builder = new NationsBuilder();
    }

    public void Run()
    {
        while((input = Console.ReadLine()) != "Quit")
        {
            var arguments = input.Split().ToList();
            var command = arguments[0];

            arguments = arguments.Skip(1).ToList();

            switch (command)
            {
                case "Bender":
                    builder.AssignBender(arguments);
                    break;

                case "Monument":
                    builder.AssignMonument(arguments);
                    break;

                case "War":
                    builder.IssueWar(arguments[0]);
                    break;

                case "Status":
                    Console.WriteLine(builder.GetStatus(arguments[0]));
                    break;
            }
        }

        Console.WriteLine(builder.GetWarsRecord());
    }
}

