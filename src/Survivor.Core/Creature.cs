using System;
using System.Collections.Generic;

namespace Survivor
{
    public class Creature
    {
        public Creature()
        {
        }

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

        public virtual void Update(IEnumerable<Creature> creatures, IEnumerable<Item> healthPacks, IEnumerable<Item> weapons, IEnumerable<Item> armors)
        {
        }

        protected void Move(Direction direction)
        {
            var command = new MoveCommand(state, direction);
            commands.Add(command);
        }

        protected void Hit(CreatureInfo enemy)
        {
            var command = new AttackCommand(state, enemy);
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
