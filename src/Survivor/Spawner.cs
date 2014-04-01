using System;
using System.Collections.Generic;

namespace Survivor
{
    public class Spawner
    {
        public int MaxItemCount
        {
            get;
            set;
        }

        public int MinStrength
        {
            get;
            set;
        }

        public int MaxStrength
        {
            get;
            set;
        }

        public void Spawn(Arena arena, List<Item> items)
        {
            if (items.Count < MaxItemCount)
            {
                int x, y;

                do
                {
                    x = random.Next(arena.Width);
                    y = random.Next(arena.Height);
                } while (arena.IsOccupied(x, y) || arena.IsCloseToCreature(x, y));

                var item = new Item(x, y);
                item.Strength = random.Next(MaxStrength - MinStrength) + MinStrength;
                items.Add(item);
            }
        }

        private Random random = new Random();
    }
}
