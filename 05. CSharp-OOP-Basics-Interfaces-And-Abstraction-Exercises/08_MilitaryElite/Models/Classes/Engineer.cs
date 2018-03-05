
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
    }
    private ICollection<IRepair> repairs = new List<IRepair>();
    public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)repairs;

    public void AddRepair(IRepair repair)
    {
        repairs.Add(repair);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"{nameof(this.Corps)}: {this.Corps.ToString()}")
            .AppendLine($"{nameof(this.Repairs)}:");

        foreach (var repair in this.Repairs)
        {
            sb.AppendLine($"  {repair.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }
}

