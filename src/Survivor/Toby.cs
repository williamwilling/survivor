using System;
using System.Collections.Generic;
using Survivor.Core;

namespace Survivor
{
    class Toby : Creature
    {
        string Direction = "Left";

        public override void Update(IReadOnlyList<Creature> creatures, IReadOnlyList<Item> items)
        {
            switch (Direction)
            {
                case "Left":
                    MoveLeft();
                    break;
                case "Up":
                    MoveUp();
                    break;
                case "Down":
                    MoveDown();
                    break;
                case "Right":
                    MoveRight();
                    break;
            }

            if (Direction == "Left" && this.X == 1)
            {
                Direction = "Down";
            }

            if (Direction == "Right" && this.X == ArenaWidth - 1)
            {
                Direction = "Up";
            }

            if (Direction == "Up" && this.Y == 1)
            {
                Direction = "Left";
            }

            if (Direction == "Down" && this.Y == ArenaHeight - 1)
            {
                Direction = "Right";
            }
        }
    }
}
