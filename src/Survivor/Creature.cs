using System;
using System.Collections.Generic;

namespace Survivor
{
    public class Creature
    {
        public Creature(string name, int x, int y)
        {
            state.Name = name;
            state.X = x;
            state.Y = y;
        }

        public string Name
        {
            get
            {
                return state.Name;
            }
        }

        public int X
        {
            get
            {
                return state.X;
            }
        }

        public int Y
        {
            get
            {
                return state.Y;
            }
        }

        public int Attack
        {
            get
            {
                return state.Attack;
            }
        }

        public int Defense
        {
            get
            {
                return state.Defense;
            }
        }

        public virtual void Update(IEnumerable<CreatureInfo> creatures)
        {
        }

        protected void Move(Direction direction)
        {
            var command = new MoveCommand(state, direction);
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
                return new IdleCommand(state);
            }

            var command = commands[0];
            commands.RemoveAt(0);
            return command;
        }

        private List<Command> commands = new List<Command>();
        private CreatureState state = new CreatureState();
    }
}
