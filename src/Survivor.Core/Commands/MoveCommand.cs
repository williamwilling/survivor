using System;
using System.Linq;

namespace Survivor.Core
{
    internal class MoveCommand : Command
    {
        internal MoveCommand(Creature creature, Direction direction)
            : base(creature)
        {
            this.direction = direction;
        }

        internal override void Do(Arena arena)
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
                //string message;

                //switch (item.Type)
                //{
                //    case ItemType.HealthPack:
                //        message = "{0} picks up a health pack and receives {1} HP.";
                //        Creature.Health += item.Strength;
                //        break;

                //    case ItemType.Weapon:
                //        message = "{0} picks up a weapon with an attack of {1}.";
                //        Creature.Attack = item.Strength;
                //        break;

                //    case ItemType.Armor:
                //        message = "{0} picks up an armor with a defense of {1}.";
                //        Creature.Defense = item.Strength;
                //        break;
                //    default:
                //        message = "{0} picks up an unknown item with strength {1}. Debug time!";
                //        throw new Exception();
                //}

                //message = String.Format(message, Creature.Name, item.Strength);
                //arena.Log.Add(message);

                bool isPickedUp = item.PickUp(Creature);

                if (isPickedUp)
                {
                    arena.InternalItems.Remove(item);
                }
            }
        }

        private Direction direction;
    }
}
