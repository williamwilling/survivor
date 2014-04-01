using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor.Core
{
    internal abstract class Command
    {
        internal Command(Creature creature)
        {
            Creature = creature;
        }

        internal abstract void Do(Arena arena);

        protected Creature Creature
        {
            get;
            private set;
        }
    }
}
