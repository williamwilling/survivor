using System;

namespace Survivor
{
    public class Creature
    {
        public Creature(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public virtual void Update()
        {
        }
    }
}
