using System;
using System.Collections.Generic;
using System.Linq;

namespace Survivor
{
    public class TestCreature : Creature
    {
        public TestCreature(int x, int y)
            : base("Test", x, y)
        {
        }

        public override void Update(IEnumerable<CreatureInfo> creatures, IEnumerable<ItemInfo> healthPacks, IEnumerable<ItemInfo> weapons, IEnumerable<ItemInfo> armors)
        {
            var healthPack = healthPacks.FirstOrDefault();
            var weapon = weapons.FirstOrDefault();
            var armor = armors.FirstOrDefault();
            var creature = creatures.FirstOrDefault();

            if (creature != null)
            {
                if (Attack > 0)
                {
                    if (creature.X == X && creature.Y == Y)
                    {
                        Hit(creature);
                    }

                    MoveTo(creature.X, creature.Y);
                }
                else
                {
                    MoveAwayFrom(creature.X, creature.Y);
                }
            }
            else if (healthPack != null)
            {
                MoveTo(healthPack.X, healthPack.Y);
            }
            else if (armor != null)
            {
                MoveTo(armor.X, armor.Y);
            }
            else if (weapon != null)
            {
                MoveTo(weapon.X, weapon.Y);
            }
            else
            {
                var direction = (Direction) random.Next(4);
                Move(direction);
            }
        }

        private void MoveAwayFrom(int x, int y)
        {
            if (x < X)
            {
                Move(Direction.Right);
            }
            else if (x > X)
            {
                Move(Direction.Left);
            }
            else if (y < Y)
            {
                Move(Direction.Down);
            }
            else if (y > Y)
            {
                Move(Direction.Up);
            }
            else
            {
                var direction = (Direction) random.Next(4);
                Move(direction);
            }
        }

        private void MoveTo(int x, int y)
        {
            if (x < X)
            {
                Move(Direction.Left);
            }
            else if (x > X)
            {
                Move(Direction.Right);
            }
            else if (y < Y)
            {
                Move(Direction.Up);
            }
            else if (y > Y)
            {
                Move(Direction.Down);
            }
        }

        private static Random random = new Random();
    }
}