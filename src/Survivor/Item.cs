using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public class Item
    {
        public Item(int x, int y)
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

        public int Strength
        {
            get;
            set;
        }
    }
}
