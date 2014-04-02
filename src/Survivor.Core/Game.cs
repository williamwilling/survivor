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

            healthSpawner = new Spawner<HealthPack>(ItemType.HealthPack);
            healthSpawner.MaxItemCount = 4;
            healthSpawner.MinStrength = 1;
            healthSpawner.MaxStrength = 1;

            weaponSpawner = new Spawner<Weapon>(ItemType.Weapon);
            weaponSpawner.MaxItemCount = 2;
            weaponSpawner.MinStrength = 2;
            weaponSpawner.MaxStrength = 4;

            armorSpawner = new Spawner<Armor>(ItemType.Armor);
            armorSpawner.MaxItemCount = 2;
            armorSpawner.MinStrength = 1;
            armorSpawner.MaxStrength = 2;
        }

        public int FramesPerSecond
        {
            get;
            set;
        }

        public void Add<T>(string name) where T : Creature, new()
        {
            var position = arena.FindEmptySpot();

            var creature = new T();
            creature.Name = name;
            creature.X = position.X;
            creature.Y = position.Y;
            creature.Health = 4;

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
            healthSpawner.Spawn(arena);
            weaponSpawner.Spawn(arena);
            armorSpawner.Spawn(arena);
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
        private Spawner<HealthPack> healthSpawner;
        private Spawner<Weapon> weaponSpawner;
        private Spawner<Armor> armorSpawner;
    }
}
