using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    public int Length { get; set; }
    public string Route { get; set; }
    public int PrizePool { get; set; }
    public Dictionary<int, Car> Participants { get; private set; }
    public List<Car> Winners { get; private set; }
    public bool IsClosed { get; set; }

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
        this.Winners = new List<Car>();
        this.IsClosed = false;
    }

    public abstract int GetPerformance(int id);

    private Dictionary<int, Car> GetWinners()
    {
        var winners = this.Participants
            .OrderByDescending(n => this.GetPerformance(n.Key))
            .Take(3).ToDictionary(n => n.Key, m => m.Value);

        return winners;
    }

    public List<int> GetPrizes()
    {
        var result = new List<int>
        {
            (this.PrizePool * 50) / 100,
            (this.PrizePool * 30) / 100,
            (this.PrizePool * 20) / 100
        };

        return result;
    }

    public string StartRace()
    {
        var winners = this.GetWinners();


        var sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length}");

        var prizes = GetPrizes();

        for (int i = 0; i < winners.Count; i++)
        {
            var car = winners.ElementAt(i);
            var performance = GetPerformance(car.Key);
            sb.AppendLine($"{i + 1}. {car.Value.Brand} {car.Value.Model} {performance}PP - ${prizes[i]}");
        }

        return sb.ToString().TrimEnd();
    }
}

