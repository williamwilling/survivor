using System;

namespace Survivor
{
    public class IdleCommand : Command
    {
        public IdleCommand(Creature creature) :
            base(creature)
        {
        }

        public override void Do()
        {
        }
    }
}
