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

        protected readonly List<IGoal> _preconditions = [];

        protected readonly List<IGoal> _effects = [];

        public List<IGoal> GetUnsatisfiedPreconditions(Blackboard blackboard)
        {
            return [.. _preconditions.Where(g => !g.Satisify(blackboard))];
        }

        public bool SatisfyGoal(IGoal goal)
        {
            foreach (var effect in _effects)
            {
                return effect.Satisify(goal);
            }

            return false;
        }

        public bool SatisfyPreconditions(Blackboard blackboard)
        {
            foreach (var cond in _preconditions)
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