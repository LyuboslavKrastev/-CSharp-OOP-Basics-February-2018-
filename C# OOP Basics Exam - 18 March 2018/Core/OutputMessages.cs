using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public static class OutputMessages
    {
        public static string CharacterIsDead => "Must be alive to perform this action!";
        public static string BagIsFull => "Bag is full!!";
        public static string ItemDoesntExist => "No item with name {0} in bag!";
        public static string InvalidName => "Name cannot be null or whitespace!";
        public static string CannotAttackSelf => "Cannot attack self!";
        public static string FriendlyFire => "Friendly fire! Both characters are from {faction} faction!";
        public static string HealEnemy => "Cannot heal enemy character!";
        public static string InvalidCharacter => "Invalid character type \"{0}\"!";
        public static string InvalidFaction => "Invalid faction \"{0}\"!";
        public static string InvalidItem => "Invalid item \"{0}\"!";
        public static string CharcterNotFound => "Character {0} not found!";
        public static string EmptyPool => "No items left in pool!";
        public static string BagIsEmpty => "Bag is empty!";
    }
}
