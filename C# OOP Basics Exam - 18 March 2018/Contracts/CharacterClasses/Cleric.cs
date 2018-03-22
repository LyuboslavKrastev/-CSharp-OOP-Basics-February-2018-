using DungeonsAndCodeWizards.Contracts.Interfaces;
using DungeonsAndCodeWizards.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Contracts.CharacterClasses
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) : base(name, 50, 25, 40, faction)
        {
            this.RestHealMultiplier = 0.5;
            this.Bag = new Backpack();
        }


        public void Heal(Character character)
        {
            base.CheckIfBothCharactersAreAlive(character);

            if (character.Faction != this.Faction)
            {
                throw new InvalidOperationException(OutputMessages.HealEnemy);
            }
            /*In my exam solution here I forgot to check for 
            overhealing (healing over the base health of the character).*/
            character.Health = Math.Min(character.BaseHealth, character.Health + this.AbilityPoints);
        }
    }
}
