using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public int Rating
    {
        get
        {
            return this.GetRating();
        }
    }

    private int GetRating()
    {
        if (!this.players.Any())
        {
            return 0;
        }
        return (int)(Math.Round(this.players.Select(p => p.SkillLevel).Average()));       
    }

    public List<Player> Players
    {
        get { return players; }
        set { players = value; }
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

    public override string ToString()
    {
        return $"{this.name} - {this.Rating}";
    }


}
