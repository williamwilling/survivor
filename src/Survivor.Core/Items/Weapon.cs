using System;

namespace Survivor.Core
{
    public class Weapon : Item
    {
        internal override bool PickUp(Creature creature)
        {
            Arena.Log.Add(String.Format(
                "{0} picks up a weapon.",
                creature.Name));

            creature.Attack = attack;
            return true;
        }

        private int attack = 3;
    }
}
