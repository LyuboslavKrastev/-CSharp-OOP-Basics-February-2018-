using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
   public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            switch (itemName)
            {
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                case "HealthPotion":
                    return new HealthPotion();
                case "PoisonPotion":
                    return new PoisonPotion();
                default:
                    throw new ArgumentException(String.Format(OutputMessages.InvalidItem, itemName));
            }
        }
    }
}
