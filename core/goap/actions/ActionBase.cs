using Quasar.core.blackboard;
using Quasar.core.goap.interfaces;
using Quasar.core.naming;
using Quasar.scenes.cats;
using System.Collections.Generic;
using System.Linq;

namespace Quasar.core.goap.actions
{
    public abstract partial class ActionBase : IAction
    {
        public abstract FastName Name { get; }

        public abstract int Cost { get; }

        protected readonly Dictionary<FastName, IGoal> _preconditions = [];

        protected readonly Dictionary<FastName, IGoal> _effects = [];

        public List<IGoal> GetUnsatisfiedPreconditions(Blackboard blackboard)
        {
            return [.. _preconditions.Select(kvp => kvp.Value).Where(g => !g.Satisify(blackboard))];
        }

        public bool SatisfyGoal(IGoal goal)
        {
            if (_effects.TryGetValue(goal.Key, out IGoal effect))
            {
                return effect.Satisify(goal);
            }

            return false;
        }

        public bool SatisfyPreconditions(Blackboard blackboard)
        {
            foreach (var cond in _preconditions.Values)
            {
                if (!cond.Satisify(blackboard))
                {
                    return false;
                }
            }

            return true;
        }

        public abstract void Execute(Cat cat, Blackboard blackboard);
    }
}