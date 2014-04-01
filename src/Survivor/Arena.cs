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
            HealthPacks = new List<HealthPack>();
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
            return IsCreature(x, y) || IsHealthPack(x, y);
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

        public List<Creature> Creatures
        {
            get;
            private set;
        }

        public List<HealthPack> HealthPacks
        {
            get;
            private set;
        }

        public List<string> Log
        {
            get;
            private set;
        }
    }
}
