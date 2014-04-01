using System;

namespace Survivor
{
    public class TestCreature : Creature
    {
        public TestCreature(int x, int y)
            : base("Test", x, y)
        {
        }

        public override void Update()
        {
            Direction direction = (Direction) random.Next(4);
            Move(direction);
        }

        private Random random = new Random();
    }
}