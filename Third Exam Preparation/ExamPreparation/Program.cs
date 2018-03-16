using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfLaps = int.Parse(Console.ReadLine());
            var trackLength = int.Parse(Console.ReadLine());

            RaceTower racetower = new RaceTower();
            racetower.SetTrackInfo(numberOfLaps, trackLength);

            var engine = new Engine(racetower);
            engine.Run();
        }
    }
}
