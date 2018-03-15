using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> wars;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            { "Air", new Nation() },
            { "Earth", new Nation()},
            { "Water", new Nation()},
            { "Fire", new Nation()}
        };

        this.wars = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var elementStrength = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Earth":
                this.nations[type].AddBender(new EarthBender(name, power, elementStrength));
                break;
            case "Air":
                this.nations[type].AddBender(new AirBender(name, power, elementStrength));
                break;
            case "Fire":
                this.nations[type].AddBender(new FireBender(name, power, elementStrength));
                break;
            case "Water":
                this.nations[type].AddBender(new WaterBender(name, power, elementStrength));
                break;
        }
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Earth":
                this.nations[type].AddMonument(new EarthMonument(name, affinity));
                break;
            case "Air":
                this.nations[type].AddMonument(new EarthMonument(name, affinity));
                break;
            case "Fire":
                this.nations[type].AddMonument(new FireMonument(name, affinity));
                break;
            case "Water":
                this.nations[type].AddMonument(new WaterMonument(name, affinity));
                break;
        }
    }
    public string GetStatus(string nationsType)
    {
        return $"{nationsType} Nation" + Environment.NewLine +
            this.nations[nationsType].ToString();
    }
    public void IssueWar(string nationsType)
    {
        this.wars.Add(nationsType);
        var winner = nations.Max(n => n.Value.GetTotalPoints());

        foreach (var nation in nations)
        {
            if (nation.Value.GetTotalPoints() != winner)
            {
                nation.Value.Die();
            }
        }
    }
    public string GetWarsRecord()
    {
        var sb = new StringBuilder();
        for (int warNumber = 0; warNumber < this.wars.Count; warNumber++)
        {
            sb.AppendLine($"War {warNumber + 1} issued by {this.wars[warNumber]}");
        }

        return sb.ToString().TrimEnd();
    }
}

