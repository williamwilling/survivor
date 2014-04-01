using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.FramesPerSecond = 10;
            game.Run();
        }
    }
}
