using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public class ItemFinder
    {
        public ItemFinder(Arena arena)
        {
            this.arena = arena;
        }

        public int MaxDistance
        {
            get;
            set;
        }

        public IEnumerable<ItemInfo> FindNear<T>(Creature creature)
        {
            var items = new List<ItemInfo>();

            foreach (var item in arena.Items)
            {
                if (item.GetType() == typeof(T))
                {
                    int distance = CalculcateDistance(creature, item);

                    if (distance <= MaxDistance)
                    {
                        var info = new ItemInfo(item);
                        items.Add(info);
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
