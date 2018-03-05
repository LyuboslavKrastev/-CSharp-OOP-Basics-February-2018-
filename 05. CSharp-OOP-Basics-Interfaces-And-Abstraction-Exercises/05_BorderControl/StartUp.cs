using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_BorderControl
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var society = new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                ProcessInput(society, input);
            }

            var fakeIds = GetFakeIds(society);

            PrintResult(fakeIds);
        }

        private static void PrintResult(IEnumerable<IIdentifiable> fakeIds)
        {
            Console.WriteLine(string.Join(Environment.NewLine, fakeIds));
        }

        private static void ProcessInput(List<IIdentifiable> society, string input)
        {
            var tokens = input.Split();
            if (tokens.Length == 2)
            {
                AddRobot(society, tokens);
            }
            else if (tokens.Length == 3)
            {
                AddCitizen(society, tokens);
            }
        }

        private static IEnumerable<IIdentifiable> GetFakeIds(List<IIdentifiable> society)
        {
            var fakeIdEnding = Console.ReadLine();
            var fakeIds = society.Where(i => i.Id.EndsWith(fakeIdEnding));

            return fakeIds;
        }

        private static void AddCitizen(List<IIdentifiable> society, string[] tokens)
        {
            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var id = tokens[2];
            society.Add(new Citizen(name, age, id));
        }

        private static void AddRobot(List<IIdentifiable> society, string[] tokens)
        {
            var model = tokens[0];
            var id = tokens[1];
            society.Add(new Robot(model, id));
        }
    }
}
