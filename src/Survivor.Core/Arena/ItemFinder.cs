using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor.Core
{
    internal class ItemFinder
    {
        internal ItemFinder(Arena arena)
        {
            this.arena = arena;
        }

        internal int MaxDistance
        {
            get;
            set;
        }

        internal IEnumerable<Item> FindNear(Creature creature, ItemType itemType)
        {
            var items = new List<Item>();

            foreach (var item in arena.Items)
            {
                if (item.Type == itemType)
                {
                    int distance = CalculcateDistance(creature, item);

                    if (distance <= MaxDistance)
                    {
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        private int CalculcateDistance(Creature creature, Item item)
        {
            int xDistance = Math.Abs(creature.X - item.X);
            int yDistance = Math.Abs(creature.Y - item.Y);
            return xDistance + yDistance;
        }

        private Arena arena;
    }
}
