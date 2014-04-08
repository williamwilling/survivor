using System;
using Survivor.Core;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.FramesPerSecond = 50;

            game.Add<DemoCreature>("Maximus");
            game.Add<DemoCreature>("Antonius");
            game.Add<Toby>("TobyBot");

            game.Run();
        }
    }
}