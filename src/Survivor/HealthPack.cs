﻿using System;
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
    }
}
