using DungeonsAndCodeWizards.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Contracts
{
    public abstract class Bag
    {
        private int Capacity { get; } = 100;
        private int Load => items.Sum(i => i.Weight);

        private IReadOnlyCollection<Item> items => (IReadOnlyCollection<Item>) Items;

        private List<Item> Items { get; set; }

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.Items = new List<Item>();
        }

        public virtual void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(OutputMessages.BagIsFull);
            }

            this.Items.Add(item);
        }

        public virtual Item GetItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.GetType().Name == name);

            if (!this.items.Any())
            {
                throw new InvalidOperationException(string.Format(OutputMessages.BagIsEmpty));
            }

            if (item == null)
            {
                throw new ArgumentException(String.Format(OutputMessages.ItemDoesntExist, name));
            }
            

            Items.Remove(item);
            return item;
        }
    }
}
