using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_FootShortage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var buyers = new List<IHuman>();
            var totalFoodBought = 0;

            int n = int.Parse(Console.ReadLine());

            ProcessInput(buyers, n);

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var currentBuyer = GetBuyer(buyers, input);
                totalFoodBought += BuyFood(currentBuyer);
            }

            PrintResult(totalFoodBought);
        }

        private static void ProcessInput(List<IHuman> buyers, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                if (tokens.Length == 4)
                {
                    AddCitizen(buyers, tokens, name, age);

                }
                else if (tokens.Length == 3)
                {
                    AddRebel(buyers, tokens, name, age);
                }
            }
        }

        private static void AddRebel(List<IHuman> buyers, string[] tokens, string name, int age)
        {
            var group = tokens[2];
            buyers.Add(new Rebel(name, age, group));
        }

        private static void AddCitizen(List<IHuman> buyers, string[] tokens, string name, int age)
        {
            var id = tokens[2];
            var birthDate = tokens[3];
            buyers.Add(new Citizen(name, age, id, birthDate));
        }

        private static void PrintResult(int totalFoodBought)
        {
            Console.WriteLine(totalFoodBought);
        }

        private static IHuman GetBuyer(List<IHuman> buyers, string input)
        {
            return buyers.FirstOrDefault(b => b.Name == input);
        }

        private static int BuyFood(IHuman currentBuyer)
        {
            if (currentBuyer != null)
            {
                currentBuyer.BuyFood();
                if (currentBuyer is Citizen)
                {
                    return 10;
                }
                else
                {
                    return 5;
                }
            }
            return 0;
        }
    }
}
