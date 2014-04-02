using System;

namespace Survivor.Core
{
    public class Armor : Item
    {
        internal override bool PickUp(Creature creature)
        {
            Arena.Log.Add(String.Format(
                "{0} picks up an armor.",
                creature.Name));

            creature.Defense = defense;
            return true;
        }

        private int defense = 1;
    }
}
