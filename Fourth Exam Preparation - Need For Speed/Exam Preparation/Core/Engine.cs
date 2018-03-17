using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private CarManager carManager;

    public Engine()
    {
        this.carManager = new CarManager();
    }

    public void Run()
    {
        string input;

        while ((input = Console.ReadLine()) != "Cops Are Here")
        {
            var inputArgs = input.Split().ToArray();


            ExecuteCommand(inputArgs);

        }
    }

    public void ExecuteCommand(string[] inputArgs)
    {
        var command = inputArgs[0];

        var cmdArgs = inputArgs.Skip(1).ToArray();

        try
        {
            switch (command)
            {
                case "register":

                    int id = int.Parse(cmdArgs[0]);
                    string type = cmdArgs[1];
                    string brand = cmdArgs[2];
                    string model = cmdArgs[3];
                    int yearOfProduction = int.Parse(cmdArgs[4]);
                    int horsepower = int.Parse(cmdArgs[5]);
                    int acceleration = int.Parse(cmdArgs[6]);
                    int suspension = int.Parse(cmdArgs[7]);
                    int durability = int.Parse(cmdArgs[8]);

                    carManager.Register(id, type, brand, model,
                        yearOfProduction, horsepower, acceleration, suspension, durability);
                    break;

                case "check":
                    var carId = int.Parse(cmdArgs[0]);
                    Console.WriteLine(carManager.Check(carId));
                    break;

                case "open":
                    int raceId = int.Parse(cmdArgs[0]);
                    string raceType = cmdArgs[1];
                    int length = int.Parse(cmdArgs[2]);
                    string route = cmdArgs[3];
                    int pricePool = int.Parse(cmdArgs[4]);
                    carManager.Open(raceId, raceType, length, route, pricePool);
                    break;

                case "participate":
                    carId = int.Parse(cmdArgs[0]);
                    raceId = int.Parse(cmdArgs[1]);
                    carManager.Participate(carId, raceId);
                    break;

                case "start":
                    raceId = int.Parse(cmdArgs[0]);
                    Console.WriteLine(carManager.Start(raceId));
                    break;

                case "park":
                    carId = int.Parse(cmdArgs[0]);
                    carManager.Park(carId);
                    break;

                case "unpark":
                    carId = int.Parse(cmdArgs[0]);
                    carManager.Unpark(carId);
                    break;

                case "tune":
                    int tuneIndex = int.Parse(cmdArgs[0]);
                    string addOn = cmdArgs[1];
                    carManager.Tune(tuneIndex, addOn);
                    break;
            }
        }
        catch
        {
        }
    }
}

