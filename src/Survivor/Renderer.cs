using System;
using System.Collections.Generic;
using System.Linq;

namespace Survivor
{
    public class Renderer
    {
        public Renderer()
        {
            LogSize = 3;
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
            Console.WindowHeight = arena.Height + LogSize;
            Console.BufferWidth = arena.Width;
            Console.BufferHeight = arena.Height + LogSize;
        }

        public void Draw(Arena arena)
        {
            Console.Clear();

            DrawHealthPacks(arena.HealthPacks);
            DrawWeapons(arena.Weapons);
            DrawCreatures(arena.Creatures);
            DrawLog(arena.Log);
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
            foreach (var healthPack in healthPacks)
            {
                Console.SetCursorPosition(healthPack.X, healthPack.Y);
                Console.Write('H');
            }
        }

        private void DrawWeapons(IEnumerable<Weapon> weapons)
        {
            foreach (var weapon in weapons)
            {
                Console.SetCursorPosition(weapon.X, weapon.Y);
                Console.Write('W');
            }
        }

        private void DrawLog(IEnumerable<string> log)
        {
            int first = log.Count() < LogSize ? 0 : log.Count() - LogSize;
            var messages = log.Skip(first).Take(3);

            int y = Console.WindowHeight - LogSize;

            foreach (var message in messages)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(message);
                y++;
            }
        }
    }
}
