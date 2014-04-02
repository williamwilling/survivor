using System;

namespace Survivor.Core
{
    public class HealthPack : Item
    {
        internal override bool PickUp(Creature creature)
        {
            if (creature.Health < 10)
            {
                Arena.Log.Add(String.Format(
                    "{0} picks up a health pack and receives {1} HP.",
                    creature.Name,
                    healthPoints));

                creature.Health += healthPoints;
                creature.SkipTurnCount += 3;
                return true;
            }

            return false;
        }

        private int healthPoints = 1;
    }
}