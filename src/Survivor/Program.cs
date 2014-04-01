using System;
using Survivor.Core;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.FramesPerSecond = 20;

            game.Add<TestCreature>("Maximus");
            game.Add<TestCreature>("Antonius");

            game.Run();
        }
    }
}