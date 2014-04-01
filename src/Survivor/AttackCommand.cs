using System;

namespace Survivor
{
    public class AttackCommand : Command
    {
        public AttackCommand(CreatureState creature, CreatureInfo enemy)
            : base(creature)
        {
            this.enemy = enemy;
        }

        public override void Do(Arena arena)
        {
            string message;

            if (Creature.Attack <= 0)
            {
                message = String.Format(
                    "{0} attacks {1} without a weapon. Nothing happens.",
                    Creature.Name,
                    enemy.Name);
            }
            else
            {
                if (Creature.X == enemy.X && Creature.Y == enemy.Y)
                {
                    int damage = Math.Max(0, Creature.Attack - enemy.Defense);

                    message = String.Format(
                        "{0} attacks {1} and does {2} damage.",
                        Creature.Name,
                        enemy.Name,
                        damage);
                }
                else
                {
                    message = String.Format(
                        "{0} tries to hit {1}, but misses.",
                        Creature.Name,
                        enemy.Name);
                }

                Creature.Attack = 0;
            }

            arena.Log.Add(message);
        }

        private CreatureInfo enemy;
    }
}
