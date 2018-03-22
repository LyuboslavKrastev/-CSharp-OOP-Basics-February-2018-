using DungeonsAndCodeWizards.Contracts.Interfaces;
using DungeonsAndCodeWizards.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Contracts.CharacterClasses
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) : base(name, 100, 50, 40, faction)
        {
            this.Bag = new Satchel();
        }

        public void Attack(Character character)
        {
            base.CheckIfBothCharactersAreAlive(character);

            if (character == this)
            {
                throw new InvalidOperationException(OutputMessages.CannotAttackSelf);
            }

            if (character.Faction == this.Faction)
            {
                throw new ArgumentException(OutputMessages.FriendlyFire);
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
