using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public class HealthPack
    {
        public HealthPack(int x, int y)
        {
            X = x;
            Y = y;
            Health = 12;
        }

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        public int Health
        {
            get;
            private set;
        }
    }
}
