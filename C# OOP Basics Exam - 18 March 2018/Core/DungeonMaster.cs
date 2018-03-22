using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Contracts.CharacterClasses;
using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core 
{
    public class DungeonMaster
    {
        private List<Character> party;
        private Stack<Item> itemPool;
        private int lastSurvivorRounds;
        private CharacterFactory charFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemPool = new Stack<Item>();
            this.lastSurvivorRounds = 0;
            this.charFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var characterType = args[1];
            var name = args[2];

            Character character = charFactory.CreateCharacter(faction, characterType, name);

            this.party.Add(character);
            return $"{character.Name} joined the party!";
        }


        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];


            var item = itemFactory.CreateItem(itemName);

            this.itemPool.Push(item);

            return $"{item.GetType().Name} added to pool.";
        }



        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            Character character = CheckIfCharacterIsInParty(characterName);


            if (!itemPool.Any())
            {
                throw new InvalidOperationException(OutputMessages.EmptyPool);
            }

            var item = itemPool.Peek();

            character.ReceiveItem(item);

            itemPool.Pop();

            return $"{character.Name} picked up {item.GetType().Name}!";
        }



        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            Character character = CheckIfCharacterIsInParty(characterName);

            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var recieverName = args[1];
            var itemName = args[2];

            var giver = CheckIfCharacterIsInParty(giverName);
            var reciever = CheckIfCharacterIsInParty(recieverName);



            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, reciever);

            return $"{giver.Name} used {itemName} on {reciever.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var recieverName = args[1];
            var itemName = args[2];

            var giver = CheckIfCharacterIsInParty(giverName);
            var reciever = CheckIfCharacterIsInParty(recieverName);

            var item = itemFactory.CreateItem(itemName);

            giver.GiveCharacterItem(item, reciever);

            return $"{giver.Name} gave {reciever.Name} {itemName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();
            foreach (var characer in party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                sb.AppendLine(characer.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var recieverName = args[1];

            var sb = new StringBuilder();

            var attacker = CheckIfCharacterIsInParty(attackerName);
            var reciever = CheckIfCharacterIsInParty(recieverName);

            if (attacker is Cleric)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            var warrior = (Warrior)attacker;
            warrior.Attack(reciever);

            sb.AppendLine($"{warrior.Name} attacks {reciever.Name} for {warrior.AbilityPoints} hit points! {reciever.Name} has {reciever.Health}/{reciever.BaseHealth} HP and {reciever.Armor}/{reciever.BaseArmor} AP left!");

            if (reciever.IsAlive == false)
            {
                sb.AppendLine($"{reciever.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var giverName = args[0];
            var recieverName = args[1];

            var healer = CheckIfCharacterIsInParty(giverName);
            var receiver = CheckIfCharacterIsInParty(recieverName);

            if (healer is Warrior)
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            var cleric = (Cleric)healer;

            cleric.Heal(receiver);

            return $"{cleric.Name} heals {receiver.Name} for {cleric.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            var sb = new StringBuilder();
            var aliveCharacters = 0;
            foreach (var character in party.Where(c => c.IsAlive == true))
            {
                var healthBeforeRest = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
                aliveCharacters++;
            }

            if (aliveCharacters == 0 || aliveCharacters == 1)
            {
                this.lastSurvivorRounds++;
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (lastSurvivorRounds > 1)
            {
                return true;
            }
            if (!party.Any(c => c.IsAlive == true))
            {
                return true;
            }
            return false;
        }




        private Character CheckIfCharacterIsInParty(string characterName)
        {
            var character = party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(OutputMessages.CharcterNotFound, characterName));
            }

            return character;
        }
    }
}
