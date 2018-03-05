using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_BirthdayCelebrations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var society = new List<IIdentifiable>();
            var petsAndOwners = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                ProcessInput(society, petsAndOwners, input);
            }

            var birthYear = Console.ReadLine();

            PrintResult(petsAndOwners, birthYear);
        }

        private static void PrintResult(List<IBirthable> petsAndOwners, string birthYear)
        {
            var result = petsAndOwners.Where(b => b.BirthDate.EndsWith(birthYear));

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static void ProcessInput(List<IIdentifiable> society, List<IBirthable> petsAndOwners, string input)
        {
            var tokens = input.Split();
            switch (tokens[0])
            {
                case "Pet":
                    AddPet(petsAndOwners, tokens);
                    break;
                case "Robot":
                    AddRobot(society, tokens);
                    break;
                case "Citizen":
                    AddCitizen(petsAndOwners, tokens);
                    break;
            }
        }


        private static void AddPet(List<IBirthable> petsAndOwners, string[] tokens)
        {
            var birthday = tokens[2];
            var name = tokens[0];
            petsAndOwners.Add(new Pet(name, birthday));
        }

        private static void AddCitizen(List<IBirthable> society, string[] tokens)
        {
            var name = tokens[1];
            var age = int.Parse(tokens[2]);
            var id = tokens[3];
            var birthDate = tokens[4];
            society.Add(new Citizen(name, age, id, birthDate));
        }

        private static void AddRobot(List<IIdentifiable> society, string[] tokens)
        {
            var model = tokens[0];
            var id = tokens[1];
            society.Add(new Robot(model, id));
        }
    }
}
