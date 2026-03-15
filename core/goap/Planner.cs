using Quasar.core.blackboard;
using Quasar.core.goap.interfaces;
using Quasar.scenes.common.interfaces;
using System.Collections.Generic;

namespace Quasar.core.goap
{
    public class Leaf
    {
        public Leaf Parent { get; set; }

        public int CumulativeCost { get; set; }

        public Blackboard Blackboard { get; set; }

        public IAction Action { get; set; }

        public bool IsSuccess { get; set; }
    }

    public partial class Planner
    {
        private WorldState _worldState = null;

        private readonly IWorkSystem _workSystem;

        private readonly IPathingSystem _pathingSystem;

        public Planner(IWorkSystem workSystem, IPathingSystem pathingSystem)
        {
            _workSystem = workSystem;
            _pathingSystem = pathingSystem;
        }

        public Plan Plan(IAgent agent, IGoal goal)
        {
            _worldState = new(agent, _workSystem, _pathingSystem);

            Leaf root = new()
            {
                Parent = null,
                CumulativeCost = 0,
                Blackboard = new(_worldState.GetBlackboard()),
                Action = null,
                IsSuccess = false,
            };

            List<Leaf> leaves = [];
            BuildPlanRec(root, leaves, goal);

            Queue<IAction> minCostPlan = [];
            int minCost = int.MaxValue;
            Blackboard blackboard = null;

            foreach (var leaf in leaves)
            {
                if (leaf.IsSuccess && leaf.CumulativeCost < minCost)
                {
                    RebuildPlan(leaf, minCostPlan);
                    minCost = leaf.CumulativeCost;
                    blackboard = leaf.Blackboard;
                }    
            }

            return new(blackboard, minCostPlan);
        }

        private void BuildPlanRec(Leaf current, List<Leaf> leaves, IGoal goal)
        {
            foreach (var action in _worldState.AvailableActions)
            {
                if (action.SatisfyGoal(goal))
                {
                    Leaf leaf = new()
                    {
                        Parent = current,
                        CumulativeCost = current.CumulativeCost + action.Cost,
                        Blackboard = new(current.Blackboard),
                        Action = action,
                        IsSuccess = false,
                    };

                    leaves.Add(leaf);

                    if (!action.SatisfyPreconditions(leaf.Blackboard))
                    {
                        var preconditons = action.GetUnsatisfiedPreconditions(leaf.Blackboard);
                        preconditons.Reverse();

                        foreach (var precondition in preconditons)
                        {
                            BuildPlanRec(leaf, leaves, precondition);
                        }
                    }
                    else
                    {
                        leaf.IsSuccess = true;
                    }
                }
            }
        }

        private void RebuildPlan(Leaf leaf, Queue<IAction> plan)
        {
            while (leaf.Parent != null)
            {
                plan.Enqueue(leaf.Action);
                leaf = leaf.Parent;
            }
        }
    }
}