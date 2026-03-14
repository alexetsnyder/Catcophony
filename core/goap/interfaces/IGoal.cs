using Quasar.core.blackboard;
using Quasar.core.naming;

namespace Quasar.core.goap.interfaces
{
    public interface IGoal
    {
        public FastName Key { get; }

        public bool Value { get; }

        public bool Satisify(IGoal goal);

        public bool Satisify(Blackboard blackboard);
    }
}