using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public abstract class Command
    {
        public Command(Creature creature)
        {
            Creature = creature;
        }

        public abstract void Do();

        protected Creature Creature
        {
            get;
            private set;
        }
    }
}
