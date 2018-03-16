using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{
    private RaceTower raceTower;

    public Engine(RaceTower racetower)
    {
        this.raceTower = racetower;
    }

    internal void Run()
    {
        while (!raceTower.raceIsOver)
        {
            var commandArgs = Console.ReadLine().Split();
            var command = commandArgs[0];
            var methodArgs = commandArgs.Skip(1).ToList();

            switch (command)
            {
                case "RegisterDriver":
                    raceTower.RegisterDriver(methodArgs);
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    var result = raceTower.CompleteLaps(methodArgs);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }              
                    break;
                case "Box":
                    raceTower.DriverBoxes(methodArgs);
                    break;
                case "ChangeWeather":
                    raceTower.ChangeWeather(methodArgs);
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}

