using System;
using System.Linq;

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

                PickUpItems(arena);
            }
        }

        private void PickUpItems(Arena arena)
        {
            var item = (from i in arena.Items
                        where i.X == Creature.X && i.Y == Creature.Y
                        select i).FirstOrDefault();

            if (item != null)
            {
                string message;

                if (item.GetType() == typeof(HealthPack))
                {
                    message = String.Format(
                        "{0} picks up a health pack and receives {1} HP.",
                        Creature.Name,
                        item.Strength);
                    Creature.Health += item.Strength;
                }
                else if (item.GetType() == typeof(Weapon))
                {
                    message = String.Format(
                        "{0} picks up a weapon with an attack of {1}.",
                        Creature.Name,
                        item.Strength);
                    Creature.Attack = item.Strength;
                }
                else
                {
                    message = String.Format(
                        "{0} picks up an unknown item with strength {1}. Debug time!",
                        Creature.Name,
                        item.Strength);
                    throw new Exception();
                }

                arena.Log.Add(message);
                arena.Items.Remove(item);
            }
        }

        private Direction direction;
    }
}
