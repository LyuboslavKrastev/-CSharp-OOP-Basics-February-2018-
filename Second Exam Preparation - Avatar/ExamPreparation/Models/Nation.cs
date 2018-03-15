using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }

    public double GetTotalPoints()
    {
        var power = this.benders.Sum(b => b.GetTotalPower());
        var bonus = this.monuments.Sum(m => m.GetMonumentBonus());

        return power += power/100 * bonus;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        GetBenders(sb);
        GetMonuments(sb);

        return sb.ToString().TrimEnd();
    }    

    private void GetBenders(StringBuilder sb)
    {
        if (benders.Any())
        {
            sb.AppendLine("Benders:");
            sb.AppendLine(string.Join(Environment.NewLine, benders));
        }
        else
        {
            sb.AppendLine("Benders: None");
        }
    }

    private void GetMonuments(StringBuilder sb)
    {
        if (monuments.Any())
        {
            sb.AppendLine("Monuments:");
            sb.AppendLine(string.Join(Environment.NewLine, monuments));
        }
        else
        {
            sb.AppendLine("Monuments: None");
        }
    }

    internal void Die()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}

