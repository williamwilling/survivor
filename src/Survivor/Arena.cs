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
    }
}
