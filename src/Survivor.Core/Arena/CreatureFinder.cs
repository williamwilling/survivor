using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor.Core
{
    internal class CreatureFinder
    {
        internal CreatureFinder(Arena arena)
        {
            this.arena = arena;
        }

        internal int MaxDistance
        {
            get;
            set;
        }

        internal IEnumerable<Creature> FindNear(Creature creature)
        {
            var creatures = new List<Creature>();

            foreach (var candidate in arena.Creatures)
            {
                if (candidate != creature)
                {
                    int distance = CalculcateDistance(creature, candidate);

                    if (distance <= MaxDistance)
                    {
                        creatures.Add(candidate);
                    }
                }
            }

            return creatures;
        }

        private int CalculcateDistance(Creature creature, Creature candidate)
        {
            int xDistance = Math.Abs(creature.X - candidate.X);
            int yDistance = Math.Abs(creature.Y - candidate.Y);
            return xDistance + yDistance;
        }

        private Arena arena;
    }
}
