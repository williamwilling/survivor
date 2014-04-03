using System;

namespace Survivor.Core
{
    public class Weapon : Item
    {
        public Weapon()
        {
            Type = ItemType.Weapon;
        }

        internal override bool PickUp(Creature creature)
        {
            Arena.Log.Add(String.Format(
                "{0} picks up a weapon.",
                creature.Name));

            creature.Attack = attack;
            creature.SkipTurnCount = 1;
            return true;
        }

        private int attack = 3;
    }
}
