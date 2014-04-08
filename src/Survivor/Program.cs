using System;
using Survivor.Core;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.FramesPerSecond = 5;

            game.Add<DemoCreature>("Maximus");
            game.Add<DemoCreature>("Antonius");
            game.Add<MyFirstCreature>("Henk");

            game.Run();
        }
    }
}