using System;
using System.Collections.Generic;
using System.Threading;

namespace Survivor.Core
{
    public class Game
    {
        public Game()
        {
            arena = new Arena(80, 25);

            healthSpawner = new Spawner(ItemType.HealthPack);
            healthSpawner.MaxItemCount = 10;
            healthSpawner.MinStrength = 5;
            healthSpawner.MaxStrength = 5;

            weaponSpawner = new Spawner(ItemType.Weapon);
            weaponSpawner.MaxItemCount = 4;
            weaponSpawner.MinStrength = 2;
            weaponSpawner.MaxStrength = 7;

            armorSpawner = new Spawner(ItemType.Armor);
            armorSpawner.MaxItemCount = 4;
            armorSpawner.MinStrength = 1;
            armorSpawner.MaxStrength = 4;
        }

        public int FramesPerSecond
        {
            get;
            set;
        }

        public void Add<T>(string name) where T : Creature, new()
        {
            var creature = new T();
            creature.Name = name;
            creature.X = 0;
            creature.Y = 0;

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
                SpawnItems();

                renderer.Draw(arena);

                Thread.Sleep(delay);
            }
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
            creatureFinder.MaxDistance = 25;

            var itemFinder = new ItemFinder(arena);
            itemFinder.MaxDistance = 15;

            foreach (var creature in arena.Creatures)
            {
                if (!creature.HasCommands)
                {
                    var nearCreatures = creatureFinder.FindNear(creature);
                    var nearHealthPacks = itemFinder.FindNear(creature, ItemType.HealthPack);
                    var nearWeapons = itemFinder.FindNear(creature, ItemType.Weapon);
                    var nearArmors = itemFinder.FindNear(creature, ItemType.Armor);

                    creature.Update(nearCreatures, nearHealthPacks, nearWeapons, nearArmors);
                }

                var command = creature.NextCommand();
                command.Do(arena);
            }
        }

        private Arena arena;
        private Spawner healthSpawner;
        private Spawner weaponSpawner;
        private Spawner armorSpawner;
    }
}
