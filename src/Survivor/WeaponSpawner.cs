using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public class WeaponSpawner
    {
        public void Spawn(Arena arena)
        {
            if (arena.Weapons.Count < 4)
            {
                int x, y;

                do
                {
                    x = random.Next(arena.Width);
                    y = random.Next(arena.Height);
                } while (arena.IsOccupied(x, y) || arena.IsCloseToCreature(x, y));

                var weapon = new Weapon(x, y);
                arena.Weapons.Add(weapon);
            }
        }

        private Random random = new Random();
    }
}
