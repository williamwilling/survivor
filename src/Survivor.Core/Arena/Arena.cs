using System;
using System.Collections.Generic;
using System.Linq;

namespace Survivor.Core
{
    public class Arena
    {
        public Arena(int width, int height)
        {
            Width = width;
            Height = height;
            InternalCreatures = new List<Creature>();
            InternalItems = new List<Item>();
            SpawnPoints = new List<SpawnPoint>();
            Log = new List<string>();
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public IEnumerable<Creature> Creatures
        {
            get
            {
                return InternalCreatures;
            }
        }

        public IEnumerable<Item> Items
        {
            get
            {
                return InternalItems;
            }
        }

        public IEnumerable<Item> HealthPacks
        {
            get
            {
                return from item in InternalItems
                       where item.Type == ItemType.HealthPack
                       select item;
            }
        }

        public IEnumerable<Item> Weapons
        {
            get
            {
                return from item in Items
                       where item.Type == ItemType.Weapon
                       select item;
            }
        }

        public IEnumerable<Item> Armors
        {
            get
            {
                return from item in Items
                       where item.Type == ItemType.Armor
                       select item;
            }
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        internal Position FindEmptySpot()
        {
            var position = new Position();

            do
            {
                position.X = random.Next(Width);
                position.Y = random.Next(Height);
            } while (IsCloseToCreature(position.X, position.Y) || IsCloseToItem(position.X, position.Y));

            return position;
        }

        internal List<Creature> InternalCreatures
        {
            get;
            private set;
        }

        internal List<Item> InternalItems
        {
            get;
            private set;
        }

        internal List<SpawnPoint> SpawnPoints
        {
            get;
            private set;
        }

        public IEnumerable<Creature> GetCreaturesAt(int x, int y)
        {
            return from creature in Creatures
                   where creature.X == x && creature.Y == y
                   select creature;
        }

        public bool IsOccupied(int x, int y)
        {
            return IsCreature(x, y) || IsItem(x, y);
        }

        public bool IsCreature(int x, int y)
        {
            foreach (var creature in Creatures)
            {
                if (creature.X == x && creature.Y == y)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsItem(int x, int y)
        {
            foreach (var item in Items)
            {
                if (item.X == x && item.Y == y)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsHealthPack(int x, int y)
        {
            foreach (var healthPack in HealthPacks)
            {
                if (healthPack.X == x && healthPack.Y == y)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsWeapon(int x, int y)
        {
            foreach (var weapon in Weapons)
            {
                if (weapon.X == x && weapon.Y == y)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsCloseToItem(int x, int y)
        {
            foreach (var item in InternalItems)
            {
                if (IsCloseTo(item, x, y))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsCloseToCreature(int x, int y)
        {
            foreach (var creature in InternalCreatures)
            {
                if (IsCloseTo(creature, x, y))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsCloseTo(Creature creature, int x, int y)
        {
            int xDistance = Math.Abs(creature.X - x);
            int yDistance = Math.Abs(creature.Y - y);

            return xDistance + yDistance < 10;
        }

        private bool IsCloseTo(Item item, int x, int y)
        {
            int xDistance = Math.Abs(item.X - x);
            int yDistance = Math.Abs(item.Y - y);

            return xDistance + yDistance < 10;
        }

        public List<string> Log
        {
            get;
            private set;
        }

        private static Random random = new Random();
    }
}
