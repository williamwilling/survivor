using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Survivor.Core
{
    public class Game
    {
        public Game()
        {
            arena = new Arena(50, 25);
            CreateSpawnPoints();
        }

        private void CreateSpawnPoints()
        {
            int x = arena.Width / 2 + random.Next(arena.Width / 2);
            int y = arena.Height / 2 + random.Next(arena.Height / 2);
            SpawnPoint spawnPoint = new SpawnPoint<HealthPack>(arena, x, y);
            spawnPoint.SpawnChance = 0.01;
            arena.SpawnPoints.Add(spawnPoint);

            x = random.Next(arena.Width / 2);
            y = arena.Height / 2 + random.Next(arena.Height / 2);
            spawnPoint = new SpawnPoint<Weapon>(arena, x, y);
            spawnPoint.SpawnChance = 0.02;
            arena.SpawnPoints.Add(spawnPoint);

            x = arena.Width / 2 + random.Next(arena.Width / 2);
            y = random.Next(arena.Height / 2);
            spawnPoint = new SpawnPoint<Armor>(arena, x, y);
            spawnPoint.SpawnChance = 0.05;
            arena.SpawnPoints.Add(spawnPoint);

            x = arena.Width / 2 + random.Next(arena.Width / 2);
            y = random.Next(arena.Height / 2);
            spawnPoint = new SpawnPoint<XPBoost>(arena, x, y);
            spawnPoint.SpawnChance = 0.03;
            arena.SpawnPoints.Add(spawnPoint);

            x = random.Next(arena.Width / 2);
            y = random.Next(arena.Height / 2);
            spawnPoint = new SpawnPoint<Weapon>(arena, x, y);
            spawnPoint.SpawnChance = 0.03;
            arena.SpawnPoints.Add(spawnPoint);
        }

        public int FramesPerSecond
        {
            get;
            set;
        }

        public void Add<T>(string name) where T : Creature, new()
        {
            var position = arena.FindEmptySpot();

            var creature = new T()
            {
                Name = name,
                X = position.X,
                Y = position.Y,
                Health = 4,
                ArenaWidth = arena.Width,
                ArenaHeight = arena.Height
            };

            arena.InternalCreatures.Add(creature);
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
                RemoveDeadCreatures();
                SpawnItems();

                renderer.Draw(arena);

                Thread.Sleep(delay);
            }
        }

        private void RemoveDeadCreatures()
        {
            var deadCreatures = arena.InternalCreatures.Where(c => c.Health <= 0);

            foreach (var creature in deadCreatures)
            {
                arena.Log.Add(String.Format("{0} dies.", creature.Name));
            }

            arena.InternalCreatures.RemoveAll(c => c.Health <= 0);
        }

        private void SpawnItems()
        {
            foreach (var spawnPoint in arena.SpawnPoints)
            {
                spawnPoint.Spawn();
            }
        }

        private void UpdateCreatures()
        {
            var creatureFinder = new CreatureFinder(arena);
            creatureFinder.MaxDistance = 10;

            var itemFinder = new ItemFinder(arena);
            itemFinder.MaxDistance = 5;

            foreach (var creature in arena.Creatures)
            {
                if (creature.SkipTurnCount > 0)
                {
                    creature.SkipTurnCount--;
                    continue;
                }

                if (!creature.HasCommands)
                {
                    var nearCreatures = creatureFinder.FindNear(creature);
                    var nearItems = itemFinder.FindNear(creature);

                    try
                    {
                        creature.Update(nearCreatures, nearItems);
                    }
                    catch (Exception e)
                    {
                        var message = String.Format(
                            "{0} makes a fatal mistake. {1}",
                            creature.Name,
                            e.GetType());

                        arena.Log.Add(message);
                        creature.Health = -1;
                    }
                }

                var command = creature.NextCommand();
                command.Do(arena);
            }
        }

        private Arena arena;
        private Random random = new Random();
    }
}
