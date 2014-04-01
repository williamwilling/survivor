using System.Text;

namespace Survivor
{
    public class TestCreature : Creature
    {
        public TestCreature(int x, int y)
            : base(x, y)
        {
        }

        public override void Update()
        {
            if (X < 80)
            {
                X = X + 1;
            }
        }
    }
}