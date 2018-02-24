
using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private Stats stats;


    public Player(string name, Stats stats)
    {
        this.Name = name;
        this.Stats = stats;
    }

    public Stats Stats
    {
        get { return stats; }
        set { stats = value; }
    }


    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public double SkillLevel
    {
        get
        {
            return this.CalculateSkillLevel();
        }
    }

    private double CalculateSkillLevel()
    {
        return (this.stats.Dribble + this.stats.Endurance
            + this.stats.Passing + this.stats.Shooting + this.stats.Sprint) / 5.0;
    }
}

