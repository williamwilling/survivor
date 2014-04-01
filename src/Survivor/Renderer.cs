using System;
using System.Collections.Generic;

namespace Survivor
{
    public class Renderer
    {
        public Renderer()
        {
            Console.CursorVisible = false;
        }

        public int LogSize
        {
            get;
            set;
        }

        public void UpdateConsoleSize(Arena arena)
        {
            Console.WindowWidth = arena.Width;
            Console.WindowHeight = arena.Height;
            Console.BufferWidth = arena.Width;
            Console.BufferHeight = arena.Height;
        }

        public void Draw(Arena arena)
        {
            DrawHealthPacks(arena.HealthPacks);
            DrawCreatures(arena.Creatures);
        }

        private void DrawCreatures(IEnumerable<Creature> creatures)
        {
            foreach (var creature in creatures)
            {
                Console.SetCursorPosition(creature.X, creature.Y);
                Console.Write('@');
            }
        }

        private void DrawHealthPacks(IEnumerable<HealthPack> healthPacks)
        {
            Console.Clear();

            foreach (var healthPack in healthPacks)
            {
                Console.SetCursorPosition(healthPack.X, healthPack.Y);
                Console.Write('H');
            }
        }
    }
}
