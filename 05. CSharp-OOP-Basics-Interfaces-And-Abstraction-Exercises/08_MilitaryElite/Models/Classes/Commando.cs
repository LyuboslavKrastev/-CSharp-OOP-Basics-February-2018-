
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
    }
    private ICollection<IMission> missions = new List<IMission>();
    public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)missions;

    public void AddMission(IMission mission)
    {
            this.missions.Add(mission);
    }

    public void CompleteMission(string CodeName)
    {
        IMission mission = this.Missions.FirstOrDefault(m => m.CodeName == CodeName);
        if (mission != null)
        {
            mission.Complete();
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"{nameof(this.Corps)}: {this.Corps.ToString()}")
            .AppendLine($"{nameof(this.Missions)}:");

        foreach (var mission in this.Missions)
        {
            sb.AppendLine($"  {mission.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }
}
