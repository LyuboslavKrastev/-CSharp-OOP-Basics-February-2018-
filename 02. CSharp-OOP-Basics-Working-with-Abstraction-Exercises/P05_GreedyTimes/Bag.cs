using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Bag
{
    private long capacity;

    public Bag(long capacity)
    {
        this.capacity = capacity;
    }

    public bool HasEnoughSpace(long amount)
    {
        return this.capacity >= this.Contents.Values.Select(x => x.Values.Sum()).Sum() + amount;
    }

    public Dictionary<string, Dictionary<string, long>> Contents { get; set; } = new Dictionary<string, Dictionary<string, long>>();


    public void AddTreasure(string name, string treasureType)
    {
        if (!this.Contents.ContainsKey(treasureType))
        {
            this.Contents[treasureType] = new Dictionary<string, long>();
        }

        if (!this.Contents[treasureType].ContainsKey(name))
        {
            this.Contents[treasureType][name] = 0;
        }
    }

    public void AddTreasure(string[] safe)
    {
        for (int i = 0; i < safe.Length; i += 2)
        {
            string input = safe[i];
            long amount = long.Parse(safe[i + 1]);

            string treasureType = GetTreasureType(input);

            if (treasureType == "")
            {
                continue;
            }
            else if (!this.HasEnoughSpace(amount))
            {
                continue;
            }

            switch (treasureType)
            {
                case "Gem":
                    if (!this.Contents.ContainsKey(treasureType))
                    {
                        if (this.Contents.ContainsKey("Gold"))
                        {
                            if (amount > this.Contents["Gold"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (this.Contents[treasureType].Values.Sum() + amount > this.Contents["Gold"].Values.Sum())
                    {
                        continue;
                    }
                    break;
                case "Cash":
                    if (!this.Contents.ContainsKey(treasureType))
                    {
                        if (this.Contents.ContainsKey("Gem"))
                        {
                            if (amount > this.Contents["Gem"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (this.Contents[treasureType].Values.Sum() + amount > this.Contents["Gem"].Values.Sum())
                    {
                        continue;
                    }
                    break;
            }

            this.AddTreasure(input, treasureType);

            this.Contents[treasureType][input] += amount;
        }
    }

    private static string GetTreasureType(string name)
    {
        string treasureType = string.Empty;

        if (name.Length == 3)
        {
            treasureType = "Cash";
        }
        else if (name.ToLower().EndsWith("gem"))
        {
            treasureType = "Gem";
        }
        else if (name.ToLower() == "gold")
        {
            treasureType = "Gold";
        }

        return treasureType;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var x in this.Contents)
        {
            sb.AppendLine($"<{x.Key}> ${x.Value.Values.Sum()}");
            foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                sb.AppendLine($"##{item2.Key} - {item2.Value}");
            }
        }
        return sb.ToString().Trim();
    }
}

