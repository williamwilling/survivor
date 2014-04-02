using System;
using System.Collections.Generic;
using System.Linq;
using Survivor.Core;

namespace Survivor
{
    public class TestCreature : Creature
    {
        public override void Update(IEnumerable<Creature> creatures, IEnumerable<Item> items)
        {
            var healthPack = items.Where(i => i.Type == ItemType.HealthPack).FirstOrDefault();
            var weapon = items.Where(i => i.Type == ItemType.Weapon).FirstOrDefault();
            var armor = items.Where(i => i.Type == ItemType.Armor).FirstOrDefault();
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
                MoveRandom();
            }
        }

        private void MoveAwayFrom(int x, int y)
        {
            if (x < X)
            {
                MoveRight();
            }
            else if (x > X)
            {
                MoveLeft();
            }
            else if (y < Y)
            {
                MoveDown();
            }
            else if (y > Y)
            {
                MoveUp();
            }
            else
            {
                MoveRandom();
            }
        }

        private void MoveTo(int x, int y)
        {
            if (x < X)
            {
                MoveLeft();
            }
            else if (x > X)
            {
                MoveRight();
            }
            else if (y < Y)
            {
                MoveUp();
            }
            else if (y > Y)
            {
                MoveDown();
            }
        }

        private void MoveRandom()
        {
            var direction = random.Next(4);

            switch (direction)
            {
                case 0:
                    MoveLeft();
                    break;

                case 1:
                    MoveRight();
                    break;

                case 2:
                    MoveUp();
                    break;

                case 3:
                    MoveDown();
                    break;
            }
        }

        private static Random random = new Random();
    }
}