using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor.Core
{
    public class Item
    {
        public int X
        {
            get;
            internal set;
        }

        public int Y
        {
            get;
            internal set;
        }

        public ItemType Type
        {
            get;
            internal set;
        }

        internal Arena Arena
        {
            get;
            set;
        }

        internal virtual bool PickUp(Creature creature)
        {
            return true;
        }
    }
}
