using System;

namespace Survivor.Core
{
    public class Armor : Item
    {
        public Armor()
        {
            Type = ItemType.Armor;
        }

        internal override bool PickUp(Creature creature)
        {
            Arena.Log.Add(String.Format(
                "{0} picks up an armor.",
                creature.Name));

            creature.Defense = defense;
            creature.SkipTurnCount += 2;
            return true;
        }

        private int defense = 1;
    }
}
