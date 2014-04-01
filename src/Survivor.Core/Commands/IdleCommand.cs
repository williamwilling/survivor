using System;

namespace Survivor.Core
{
    internal class IdleCommand : Command
    {
        internal IdleCommand(Creature creature) :
            base(creature)
        {
        }

        internal override void Do(Arena arena)
        {
        }
    }
}