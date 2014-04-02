using System;
using System.Collections.Generic;
using System.Linq;

namespace Survivor.Core
{
    public class Renderer
    {
        public Renderer()
        {
            LogSize = 3;
            StatsWidth = 30;
            Console.CursorVisible = false;
        }

        public int LogSize
        {
            get;
            set;
        }

        public int StatsWidth
        {
            get;
            set;
        }

        public void UpdateConsoleSize(Arena arena)
        {
            Console.WindowWidth = arena.Width + StatsWidth;
            Console.WindowHeight = arena.Height + LogSize;
            Console.BufferWidth = arena.Width + StatsWidth;
            Console.BufferHeight = arena.Height + LogSize;
        }

        public void Draw(Arena arena)
        {
            Console.Clear();

            DrawItems(arena.HealthPacks, 'H');
            DrawItems(arena.Weapons, 'W');
            DrawItems(arena.Armors, 'A');
            DrawCreatures(arena.Creatures);
            DrawLog(arena.Log);
            DrawStats(arena.Creatures, arena);
        }

        private void DrawStats(IEnumerable<Creature> creatures, Arena arena)
        {
            int x = arena.Width + 2;
            int y = 0;
            

            foreach (var creature in creatures)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(creature.Name);

                y++;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(String.Format(
                    "HP: {0} - Att: {1} - Def: {2}",
                    creature.Health,
                    creature.Attack,
                    creature.Defense));
                y += 2;
            }
        }

        private void DrawCreatures(IEnumerable<Creature> creatures)
        {
            foreach (var creature in creatures)
            {
                Console.SetCursorPosition(creature.X, creature.Y);
                Console.Write('@');
            }
        }

        private void DrawItems(IEnumerable<Item> items, char symbol)
        {
            foreach (var item in items)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(symbol);
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
