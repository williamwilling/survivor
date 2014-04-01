using System;
using System.Collections.Generic;
using System.Threading;

namespace Survivor
{
    public class Game
    {
        public Game()
        {
            arena.Creatures.Add(new TestCreature(10, 2));
            arena.Creatures.Add(new TestCreature(4, 5));
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

            var healthSpawner = new HealthSpawner();

            while (true)
            {
                UpdateCreatures();
                SpawnItems();
                PickUpItems();

                Draw();

                Thread.Sleep(delay);
            }
        }

        private void PickUpItems()
        {
            for (int i = 0; i < arena.HealthPacks.Count; i++)
            {
                var healthPack = arena.HealthPacks[i];
                var creature = GetCreatureAt(healthPack.X, healthPack.Y);

                if (creature != null)
                {
                    arena.HealthPacks.RemoveAt(i);
                    i--;
                }
            }
        }

        private Creature GetCreatureAt(int x, int y)
        {
            foreach (var creature in arena.Creatures)
            {
                if (creature.X == x && creature.Y == y)
                {
                    return creature;
                }
            }

            return null;
        }

        private void SpawnItems()
        {
            healthSpawner.Spawn(arena);
        }

        private void UpdateCreatures()
        {
            foreach (var creature in arena.Creatures)
            {
                if (!creature.HasCommands)
                {
                    creature.Update();
                }

                var command = creature.NextCommand();
                command.Do(arena);
            }
        }

        private void Draw()
        {
            Console.CursorVisible = false;
            Console.Clear();

            foreach (var healthPack in arena.HealthPacks)
            {
                Console.SetCursorPosition(healthPack.X, healthPack.Y);
                Console.Write('H');
            }

            foreach (var creature in arena.Creatures)
            {
                Console.SetCursorPosition(creature.X, creature.Y);
                Console.Write('@');
            }
        }

        private Arena arena = new Arena(80, 25);
        private HealthSpawner healthSpawner = new HealthSpawner();
    }
}
