using System;
using System.Collections.Generic;
using Survivor.Core;

namespace Survivor
{
    public class DemoCreature : Creature
    {
        public override void Update(IReadOnlyList<Creature> creatures, IReadOnlyList<Item> items)
        {
            // Is there a creature in the vicinity?
            if (creatures.Count > 0)
            {
                // Yes, do we have a weapon?
                if (Attack > 0)
                {
                    // Yes, are we on top of the creature?
                    var creature = creatures[0];

                    if (creature.X == X && creature.Y == Y)
                    {
                        // Yes, hit the creature with our weapon.
                        Hit(creature);
                        return;
                    }
                    else
                    {
                        // No, move towards the creature.
                        MoveTo(creature.X, creature.Y);
                        return;
                    }
                }
            }

            // Is there an item in the vicinity?
            if (items.Count > 0)
            {
                // Yes, go get it.
                var item = items[0];
                MoveTo(item.X, item.Y);
            }
            else
            {
                // No, just wander around for a bit until we find something.
                Wander();
            }
        }

        private void MoveTo(int x, int y)
        {
            if (x < X)
            {
                MoveLeft();
            }
            else if (y > Y)
            {
                MoveDown();
            }
            else if (x > X)
            {
                MoveRight();
            }
            else if (y < Y)
            {
                MoveUp();
            }
        }

        private void Wander()
        {
            // Do we need a new random destination?
            if ((X == randomX && Y == randomY) ||
                (randomX < 0 || randomY < 0))
            {
                // Yes, pick a random destination.
                randomX = random.Next(ArenaWidth);
                randomY = random.Next(ArenaHeight);
            }

            // Move towards the random destination.
            MoveTo(randomX, randomY);
        }

        private static Random random = new Random();
        private int randomX = -1;
        private int randomY = -1;
    }
}
