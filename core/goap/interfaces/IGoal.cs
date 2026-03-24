using Catcophony.core.blackboard;
using Catcophony.core.naming;

namespace Catcophony.core.goap.interfaces
{
    public interface IGoal
    {
        public int ActionId { get; }

        public FastName Key { get; }

        public bool Value { get; }

        public void SetActionId(int actionId);

        public bool Satisify(IGoal goal);

        public bool Satisify(WorldState worldState, Blackboard<FastName> blackboard);
    }
}