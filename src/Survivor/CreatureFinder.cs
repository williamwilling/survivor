using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public class CreatureFinder
    {
        public CreatureFinder(Arena arena)
        {
            this.arena = arena;
        }

        public int MaxDistance
        {
            get;
            set;
        }

        public IEnumerable<CreatureInfo> FindNear(Creature creature)
        {
            var creatures = new List<CreatureInfo>();

            foreach (var candidate in arena.Creatures)
            {
                if (candidate != creature)
                {
                    int distance = CalculcateDistance(creature, candidate);

                    if (distance <= MaxDistance)
                    {
                        var info = new CreatureInfo(candidate);
                        creatures.Add(info);
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
