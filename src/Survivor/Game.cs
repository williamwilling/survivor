using System;
using System.Collections.Generic;
using System.Threading;

namespace Survivor
{
    public class Game
    {
        public Game()
        {
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
            for (int i = 0; i < healthPacks.Count; i++)
            {
                var healthPack = healthPacks[i];
                var creature = GetCreatureAt(healthPack.X, healthPack.Y);

                if (creature != null)
                {
                    healthPacks.RemoveAt(i);
                    i--;
                }
            }
        }

        private Creature GetCreatureAt(int x, int y)
        {
            foreach (var creature in creatures)
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
            healthSpawner.Spawn(creatures, healthPacks);
        }

        private void UpdateCreatures()
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
        }

        private void Draw()
        {
            Console.CursorVisible = false;
            Console.Clear();

            foreach (var healthPack in healthPacks)
            {
                Console.SetCursorPosition(healthPack.X, healthPack.Y);
                Console.Write('H');
            }

            foreach (var creature in creatures)
            {
                Console.SetCursorPosition(creature.X, creature.Y);
                Console.Write('@');
            }
        }

        private List<Creature> creatures = new List<Creature>();
        private List<HealthPack> healthPacks = new List<HealthPack>();
        private HealthSpawner healthSpawner = new HealthSpawner();
    }
}
