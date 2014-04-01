using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public class CreatureInfo
    {
        public CreatureInfo(Creature creature)
        {
            X = creature.X;
            Y = creature.Y;
        }

        public int X;
        public int Y;
    }
}
