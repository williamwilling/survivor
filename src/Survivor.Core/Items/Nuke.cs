using System;

namespace Survivor.Core
{
    public class Nuke : Item
    {
        public Nuke()
        {
            Type = ItemType.Nuke;
        }

        internal override bool PickUp(Creature creature)
        {
            Arena.Log.Add(String.Format(
                "{0} picked up a Nuke, bye bye!",
                creature.Name));

            var Creatures = Arena.Creatures;

            foreach (var foundCreature in Creatures)
            {
                    //Arena.Log.Add(String.Format("{0} died by a Nuke!", foundCreature.Name));
                    foundCreature.Health = 0;
            }
            return true;
        }
    }
}
