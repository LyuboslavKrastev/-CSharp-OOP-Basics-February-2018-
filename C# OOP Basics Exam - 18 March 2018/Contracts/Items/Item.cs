using DungeonsAndCodeWizards.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Contracts
{
    public abstract class Item
    {
        public int Weight { get; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterIsDead);
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
