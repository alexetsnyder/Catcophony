using Quasar.core.blackboard;
using Quasar.core.goap.interfaces;
using Quasar.core.naming;
using System.Collections.Generic;

namespace Quasar.core.goap.goals
{
    public partial class WorkGoal : IGoal
    {
        public FastName Key { get => _key; }

        public bool Value { get => _conditions[Key]; }

        private readonly Dictionary<FastName, bool> _conditions = [];

        private readonly FastName _key = new("HasWorked");

        public WorkGoal()
        {
            _conditions.Add(Key, true);
        }

        public bool Satisify(IGoal goal)
        {
            return (Key == goal.Key && Value == goal.Value);
        }

        public bool Satisify(Blackboard blackboard)
        {
            throw new System.NotImplementedException();
        }
    }
}