using System;
using System.Collections.Generic;
using System.Linq;

namespace Survivor
{
    public class Spawner<T> where T : Item, new()
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

        public void Spawn(Arena arena, IEnumerable<T> items)
        {
            if (items.Count() < MaxItemCount)
            {
                int x, y;

                do
                {
                    x = random.Next(arena.Width);
                    y = random.Next(arena.Height);
                } while (arena.IsOccupied(x, y) || arena.IsCloseToCreature(x, y));

                var item = new T();
                item.X = x;
                item.Y = y;
                item.Strength = random.Next(MaxStrength - MinStrength) + MinStrength;
                arena.Items.Add(item);
            }
        }

        private Random random = new Random();
    }
}
