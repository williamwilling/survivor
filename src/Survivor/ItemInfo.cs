using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public class ItemInfo
    {
        public ItemInfo(Item item)
        {
            X = item.X;
            Y = item.Y;
            Strength = item.Strength;
        }

        public int X;
        public int Y;
        public int Strength;
    }
}
