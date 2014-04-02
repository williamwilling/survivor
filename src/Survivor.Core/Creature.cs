using System;
using System.Collections.Generic;

namespace Survivor.Core
{
    public abstract class Creature
    {
        public string Name
        {
            get;
            internal set;
        }

        public int X
        {
            get;
            internal set;
        }

        public int Y
        {
            get;
            internal set;
        }

        public int Health
        {
            get;
            internal set;
        }

        public int Attack
        {
            get;
            internal set;
        }

        public int Defense
        {
            get;
            internal set;
        }

        public virtual void Update(IEnumerable<Creature> creatures, IEnumerable<Item> items)
        {
        }

        protected void MoveLeft()
        {
            var command = new MoveCommand(this, Direction.Left);
            commands.Add(command);
        }

        protected void MoveRight()
        {
            var command = new MoveCommand(this, Direction.Right);
            commands.Add(command);
        }

        protected void MoveUp()
        {
            var command = new MoveCommand(this, Direction.Up);
            commands.Add(command);
        }

        protected void MoveDown()
        {
            var command = new MoveCommand(this, Direction.Down);
            commands.Add(command);
        }

        protected void Hit(Creature enemy)
        {
            var command = new AttackCommand(this, enemy);
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
