using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public abstract class Command
    {
        public Command(CreatureState creature)
        {
            Creature = creature;
        }

        public abstract void Do(Arena arena);

        protected CreatureState Creature
        {
            get;
            private set;
        }
    }
}
