using Quasar.core.blackboard;
using System.Collections.Generic;

namespace Quasar.core.goap.interfaces
{
    public interface IAction
    {
        public int Cost { get; }

        public List<IGoal> GetUnsatisfiedPreconditions(Blackboard blackboard);

        public bool SatisfyGoal(IGoal goal);

        public bool SatisfyPreconditions(Blackboard blackboard);
    }
}