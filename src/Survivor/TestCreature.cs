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

        public override void Update(IEnumerable<CreatureInfo> creatures)
        {
            var creature = creatures.FirstOrDefault();

            if (creature != null)
            {
                if (X < creature.X)
                {
                    Move(Direction.Left);
                }
                else
                {
                    Move(Direction.Right);
                }

                if (Y < creature.Y)
                {
                    Move(Direction.Up);
                }
                else
                {
                    Move(Direction.Down);
                }
            }
            else
            {
                var direction = (Direction) random.Next(4);
                Move(direction);
            }
        }

        private static Random random = new Random();
    }
}