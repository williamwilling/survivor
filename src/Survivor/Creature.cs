using System;
using System.Collections.Generic;

namespace Survivor
{
    public class Creature
    {
        public Creature(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public virtual void Update()
        {
        }

        protected void Move(Direction direction)
        {
            var command = new MoveCommand(this, direction);
            commands.Add(command);
        }

        internal bool HasCommands
        {
            get
            {
                return commands.Count > 0;
            }
        }

        internal Command NextCommand()
        {
            if (!HasCommands)
            {
                return new IdleCommand(this);
            }

            var command = commands[0];
            commands.RemoveAt(0);
            return command;
        }

        private List<Command> commands = new List<Command>();
    }
}
