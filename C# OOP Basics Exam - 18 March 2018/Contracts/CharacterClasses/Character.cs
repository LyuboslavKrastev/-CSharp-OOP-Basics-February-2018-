using DungeonsAndCodeWizards.Core;
using System;
namespace DungeonsAndCodeWizards.Contracts
{
    public abstract class Character
    {
        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Faction faction)
        {
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.BaseHealth = health;
            this.BaseArmor = armor;
            this.RestHealMultiplier = 0.2;
            this.IsAlive = true;
            this.Name = name;
            this.Faction = faction;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(OutputMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; }
        public double Health { get; set; }

        public double BaseArmor { get; }
        public double Armor { get; set; }

        public double AbilityPoints { get; }

        public Bag Bag { get; set; } //////

        public Faction Faction { get; }

        public bool IsAlive { get; protected set; }

        protected virtual double RestHealMultiplier { get; set; }

        public void TakeDamage(double hitPoints)
        {
            CheckIfAlive();

            var armorPoints = this.Armor;
            this.Armor -= hitPoints;
            hitPoints -= armorPoints;

            if (this.Armor < 0)
            {
                this.Armor = 0;
            }

            if (hitPoints > 0)
            {
                this.Health -= hitPoints;
            }

            if (this.Health < 0)
            {
                this.Die();
            }
        }

        public void Rest()
        {
            CheckIfAlive();

            this.Health = Math.Min(BaseHealth, Health + (BaseHealth * this.RestHealMultiplier));
        }

        public void CheckIfAlive()
        {
            if (!this.IsAlive)
            {
                //on the exam solution I was throwing an ArgumentException here by mistake and it cost me some IO points.
                throw new InvalidOperationException(OutputMessages.CharacterIsDead);               
            }
        }

        public void UseItem(Item item)
        {
            CheckIfAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            CheckIfBothCharactersAreAlive(character);

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character) //?
        {
            CheckIfBothCharactersAreAlive(character);

            this.Bag.GetItem(item.GetType().Name);

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            CheckIfAlive();

            this.Bag.AddItem(item);
        }

        protected void CheckIfBothCharactersAreAlive(Character character)
        {
            CheckIfAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterIsDead);
            }
        }

        public void Die()
        {
            this.Health = 0;
            this.IsAlive = false;
        }

        public override string ToString()
        {
            var status = "Alive";
            if (this.IsAlive == false)
            {
                status = "Dead";
            }
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}
