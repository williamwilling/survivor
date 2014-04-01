using System;

namespace Survivor
{
    public class IdleCommand : Command
    {
        public IdleCommand(CreatureState creature) :
            base(creature)
        {
        }

        public override void Do(Arena arena)
        {
        }
    }
}