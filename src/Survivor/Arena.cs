using System;
using System.Collections.Generic;

namespace Survivor
{
    public class Arena
    {
        public Arena()
        {
            Creatures = new List<Creature>();
            HealthPacks = new List<HealthPack>();
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
