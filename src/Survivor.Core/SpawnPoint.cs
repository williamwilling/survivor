using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor.Core
{
    internal abstract class SpawnPoint
    {
        internal abstract void Spawn();

        protected internal int X
        {
            get;
            protected set;
        }

        protected internal int Y
        {
            get;
            protected set;
        }

        internal double SpawnChance
        {
            get;
            set;
        }
    }

    internal class SpawnPoint<T> : SpawnPoint where T : Item, new()
    {
        internal SpawnPoint(Arena arena, int x, int y)
        {
            X = x;
            Y = y;
            SpawnChance = 1.0;
            this.arena = arena;
        }

        internal override void Spawn()
        {
            if (!arena.IsOccupied(X, Y))
            {
                double chance = random.NextDouble();

                if (chance < SpawnChance)
                {
                    var item = new T();
                    item.X = X;
                    item.Y = Y;
                    item.Arena = arena;

                    arena.InternalItems.Add(item);
                }
            }
        }

        private Arena arena;
        private static Random random = new Random();
    }
}
