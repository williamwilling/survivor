using System;
using System.Collections.Generic;
using System.Linq;

namespace Survivor
{
    public class Arena
    {
        public Arena(int width, int height)
        {
            Width = width;
            Height = height;
            Creatures = new List<Creature>();
            Items = new List<Item>();
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

        public IEnumerable<Creature> GetCreaturesAt(int x, int y)
        {
            return from creature in Creatures
                   where creature.X == x && creature.Y == y
                   select creature;
        }

        public bool IsOccupied(int x, int y)
        {
            return IsCreature(x, y) || IsHealthPack(x, y) || IsWeapon(x, y);
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

        public bool IsCloseToCreature(int x, int y)
        {
            foreach (var creature in Creatures)
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

        public List<Creature> Creatures
        {
            get;
            private set;
        }

        public List<Item> Items
        {
            get;
            private set;
        }

        public IEnumerable<HealthPack> HealthPacks
        {
            get
            {
                return from item in Items
                       where item.GetType() == typeof(HealthPack)
                       select item as HealthPack;
            }
        }

        public IEnumerable<Weapon> Weapons
        {
            get
            {
                return from item in Items
                       where item.GetType() == typeof(Weapon)
                       select item as Weapon;
            }
        }

        public List<string> Log
        {
            get;
            private set;
        }
    }
}
