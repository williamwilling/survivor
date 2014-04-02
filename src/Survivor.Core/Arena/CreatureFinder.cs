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

        internal IReadOnlyList<Creature> FindNear(Creature creature)
        {
            var creatures = from c in arena.Creatures
                            where c != creature && CalculateDistance(creature, c) <= MaxDistance
                            select c;

            return creatures.ToList();
        }

        private int CalculateDistance(Creature creature, Creature candidate)
        {
            int xDistance = Math.Abs(creature.X - candidate.X);
            int yDistance = Math.Abs(creature.Y - candidate.Y);
            return xDistance + yDistance;
        }

        private Arena arena;
    }
}
