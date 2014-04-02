using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor.Core
{
    internal class SpawnPoint
    {
        internal SpawnPoint(Arena arena, int x, int y)
        {
            X = x;
            Y = y;
            this.arena = arena;
        }

        internal int X
        {
            get;
            private set;
        }

        internal int Y
        {
            get;
            private set;
        }

        internal void Spawn()
        {
            if (!arena.IsOccupied(X, Y))
            {
                int spawnChance = random.Next(100);

                if (spawnChance < 5)
                {
                    int itemType = random.Next(3);
                    Item item = null;

                    switch (itemType)
                    {
                        case 0:
                            item = new HealthPack();
                            item.Type = ItemType.HealthPack;
                            break;

                        case 1:
                            item = new Armor();
                            item.Type = ItemType.Armor;
                            break;

                        case 2:
                            item = new Weapon();
                            item.Type = ItemType.Weapon;
                            break;

                        default:
                            throw new InvalidOperationException();
                    }

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
