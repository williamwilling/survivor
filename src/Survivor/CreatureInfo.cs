using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public class CreatureInfo
    {
        public CreatureInfo(Creature creature)
        {
            Name = creature.Name;
            X = creature.X;
            Y = creature.Y;
            Attack = creature.Attack;
            Defense = creature.Defense;
        }

        public int X;
        public int Y;
        public string Name;
        public int Attack;
        public int Defense;
    }
}
