using System;

namespace Survivor.Core
{
    public class XPBoost : Item
    {
        public XPBoost()
        {
            Type = ItemType.XPBoost;
        }

        internal override bool PickUp(Creature creature)
        {
            Arena.Log.Add(String.Format(
                "{0} picks up an XP Boost.",
                creature.Name));

            creature.XP += xp;
            creature.SkipTurnCount += 2;
            return true;
        }

        private int xp = 1000;
    }
}
