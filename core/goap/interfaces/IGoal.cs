using Quasar.core.blackboard;

namespace Quasar.core.goap.interfaces
{
    public interface IGoal
    {
        public bool Satisfy(Blackboard blackboard);
    }
}