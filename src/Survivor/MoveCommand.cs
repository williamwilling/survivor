using System;

namespace Survivor
{
    public class MoveCommand : Command
    {
        public MoveCommand(CreatureState creature, Direction direction)
            : base(creature)
        {
            this.direction = direction;
        }

        public override void Do(Arena arena)
        {
            int x = Creature.X;
            int y = Creature.Y;

            if (direction == Direction.Up)
            {
                y--;
            }

            if (direction == Direction.Down)
            {
                y++;
            }

            if (direction == Direction.Left)
            {
                x--;
            }

            if (direction == Direction.Right)
            {
                x++;
            }

            if (x >= 0 && x < arena.Width && y >= 0 && y < arena.Height)
            {
                Creature.X = x;
                Creature.Y = y;
            }
        }

        private Direction direction;
    }
}
