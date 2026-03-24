using Catcophony.core.blackboard;
using Catcophony.core.naming;
using Catcophony.scenes.cats;
using Catcophony.scenes.common.interfaces;
using System.Collections.Generic;

namespace Catcophony.core.goap.interfaces
{
    public interface IAction
    {
        public int Id { get; }

        public FastName Name { get; }

        public int Cost { get; }

        public bool SkipAssign { get; }

        public Blackboard<FastName> GetBlackboard();

        public void SetId(int id);

        public void SetPreconditions(List<IGoal> preconditions);

        public void SetEffects(List<IGoal> effects);

        public void LinkParent(IAction parent);

        public void LinkChild(IAction child);

        public List<IGoal> GetUnsatisfiedPreconditions(WorldState worldState);

        public bool SatisfyGoal(IGoal goal);

        public bool SatisfyPreconditions(WorldState worldState);

        public bool Assign(IWorkSystem workSystem, bool assign = true);

        public void Execute(Cat cat);
    }
}