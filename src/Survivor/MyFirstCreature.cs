using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survivor.Core;

namespace Survivor
{
    class MyFirstCreature : Creature
    {
        public override void Update(IReadOnlyList<Creature> creatures, IReadOnlyList<Item> items)
        {
            MoveLeft();
        }
    }
}
