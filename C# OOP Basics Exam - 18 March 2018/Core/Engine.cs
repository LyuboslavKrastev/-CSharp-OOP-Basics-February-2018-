using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;
        private bool GameIsOver = false;
        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {

            while (GameIsOver == false)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                var inputArgs = input.Split().ToArray();


                ExecuteCommand(inputArgs);

            }
            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }

        public void ExecuteCommand(string[] inputArgs)
        {
            var command = inputArgs[0];

            var cmdArgs = inputArgs.Skip(1).ToArray();

            try
            {
                switch (command)
                {
                    case "JoinParty":
                        Console.WriteLine(dungeonMaster.JoinParty(cmdArgs));
                        break;
                    case "AddItemToPool":
                       Console.WriteLine(dungeonMaster.AddItemToPool(cmdArgs));
                        break;
                    case "PickUpItem":
                        Console.WriteLine(dungeonMaster.PickUpItem(cmdArgs)); 
                        break;
                    case "UseItem":
                        Console.WriteLine(dungeonMaster.UseItem(cmdArgs)); 
                        break;
                    case "UseItemOn":
                        Console.WriteLine(dungeonMaster.UseItemOn(cmdArgs)); 
                        break;
                    case "GiveCharacterItem":
                        Console.WriteLine(dungeonMaster.GiveCharacterItem(cmdArgs)); 
                        break;
                    case "GetStats":
                        Console.WriteLine(dungeonMaster.GetStats()); 
                        break;
                    case "Attack":
                        Console.WriteLine(dungeonMaster.Attack(cmdArgs)); 
                        break;
                    case "Heal":
                        Console.WriteLine(dungeonMaster.Heal(cmdArgs)); 
                        break;
                    case "EndTurn":
                        Console.WriteLine(dungeonMaster.EndTurn(cmdArgs)); 
                        break;
                    case "IsGameOver":
                        this.GameIsOver = dungeonMaster.IsGameOver();
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"Parameter Error: {ae.Message}");
            }
            catch (InvalidOperationException io)
            {
                Console.WriteLine($"Invalid Operation: {io.Message}");
            }
        }
    }
}
