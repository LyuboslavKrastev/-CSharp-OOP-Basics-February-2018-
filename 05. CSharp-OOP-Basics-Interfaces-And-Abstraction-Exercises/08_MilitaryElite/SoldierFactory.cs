
using System;
using System.Collections.Generic;
using System.Linq;

public class SoldierFactory
    {
    public static ISoldier CreateSoldier(List<ISoldier> soldiers, string[] tokens, string soldierType, int id, string firstName, string lastName, decimal salary)
    {
        switch (soldierType)
        {
            case "Private":
                return new Private(id, firstName, lastName, salary);

            case "LeutenantGeneral":
                var commandingSoldiers = tokens.Skip(5);
                var liutenant = new LeutenantGeneral(id, firstName, lastName, salary);

                GetPrivates(soldiers, tokens, liutenant);

                return liutenant;
            case "Commando":
                var commandoCorps = tokens[5];
                var commando = new Commando(id, firstName, lastName, salary, commandoCorps);

                GetMissions(tokens, commando);

                return commando;

            case "Engineer":
                var engineerCorps = tokens[5];
                var repairs = tokens.Skip(5);
                var engineer = new Engineer(id, firstName, lastName, salary, engineerCorps);
                GetRepairs(tokens, engineer);

                return engineer;

            case "Spy":
                var codeNumber = (int)salary;

                return new Spy(id, firstName, lastName, codeNumber);
            default:
                return null;
        }
    }

    private static void GetPrivates(List<ISoldier> soldiers, string[] tokens, LeutenantGeneral liutenant)
    {
        for (int i = 5; i < tokens.Length; i++)
        {
            var privateId = int.Parse(tokens[i]);
            ISoldier @private = soldiers.FirstOrDefault(p => p.Id == privateId);
            liutenant.AddPrivate(@private);
        }
    }

    private static void GetRepairs(string[] tokens, Engineer engineer)
    {
        for (int i = 6; i < tokens.Length; i++)
        {
            var partName = tokens[i];
            var hoursWorked = int.Parse(tokens[++i]);
            IRepair repair = new Repair(partName, hoursWorked);
            engineer.AddRepair(repair);
        }
    }

    private static void GetMissions(string[] tokens, Commando commando)
    {
        for (int i = 6; i < tokens.Length; i++)
        {
            var codeName = tokens[i];
            var missionState = tokens[++i];
            try
            {
                IMission mission = new Mission(codeName, missionState);
                commando.AddMission(mission);
            }
            catch (Exception)
            {
            }
        }
    }
}
