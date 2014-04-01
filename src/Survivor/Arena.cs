using System;
using System.Collections.Generic;

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
