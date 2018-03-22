using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Contracts.CharacterClasses;
using DungeonsAndCodeWizards.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            bool IsValidFaction = Enum.TryParse(typeof(Faction), faction, out object factionObj);

            if (!IsValidFaction)
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidFaction, faction));
            }

            var validFaction = (Faction)factionObj;


            if (characterType == "Warrior")
            {

                return new Warrior(name, validFaction);
            }
            else if (characterType == "Cleric")
            {
                return new Cleric(name, validFaction);
            }

            throw new ArgumentException(string.Format(OutputMessages.InvalidCharacter, characterType));

        }
    }
}
