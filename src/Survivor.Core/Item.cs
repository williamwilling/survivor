﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public abstract class Item
    {
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

        public int Strength
        {
            get;
            set;
        }
    }
}