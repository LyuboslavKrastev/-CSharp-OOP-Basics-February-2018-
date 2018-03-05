using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var soldiers = new List<ISoldier>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                var soldierType = tokens[0];
                var id = int.Parse(tokens[1]);
                var firstName = tokens[2];
                var lastName = tokens[3];
                var salary = decimal.Parse(tokens[4]);

                ISoldier soldier = null;

                try
                {
                    soldier = SoldierFactory.CreateSoldier(soldiers, tokens, soldierType, id, firstName, lastName, salary);
                }
                catch
                {
                }
                soldiers.Add(soldier);
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        
    }
}
