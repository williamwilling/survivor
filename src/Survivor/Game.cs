using System;
using System.Collections.Generic;
using System.Threading;

namespace Survivor
{
    public class Game
    {
        public Game()
        {
            creatures = new List<Creature>();
            creatures.Add(new TestCreature(10, 2));
            creatures.Add(new TestCreature(4, 5));
        }

        public int FramesPerSecond
        {
            get;
            set;
        }

        public void Run()
        {
            int fps = FramesPerSecond > 0 ? FramesPerSecond : 1;
            int delay = (int) (1000.0 / fps);

            while (true)
            {
                foreach (var creature in creatures)
                {
                    if (!creature.HasCommands)
                    {
                        creature.Update();
                    }

                    var command = creature.NextCommand();
                    command.Do();
                }

                Draw();

                Thread.Sleep(delay);
            }
        }

        private void Draw()
        {
            Console.CursorVisible = false;
            Console.Clear();

            foreach (var creature in creatures)
            {
                Console.SetCursorPosition(creature.X, creature.Y);
                Console.Write('@');
            }
        }

        private List<Creature> creatures;
    }
}
