using System;
using System.Collections.Generic;
using System.Threading;

namespace Survivor
{
    public class Game
    {
        public Game()
        {
            arena = new Arena(80, 25);
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
            
            var renderer = new Renderer();
            renderer.UpdateConsoleSize(arena);

            while (true)
            {
                UpdateCreatures();
                SpawnItems();

                renderer.Draw(arena);

                Thread.Sleep(delay);
            }
        }

        private void SpawnItems()
        {
            healthSpawner.Spawn(arena);
            weaponSpawner.Spawn(arena);
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

        private Arena arena;
        private HealthSpawner healthSpawner = new HealthSpawner();
        private WeaponSpawner weaponSpawner = new WeaponSpawner();
    }
}
